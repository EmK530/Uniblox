using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using static Unity.Burst.Intrinsics.X86.Avx;

// RBXL Importer for Uniblox

public class GameLoader : MonoBehaviour
{
    public string TargetBinaryName = "resources.bytes";
    public Transform DataModel;

    private ByteReader reader;
    private int state = 0;

    public static UnityEvent GameLoadCompleted = new UnityEvent();

    void Start()
    {
        TextAsset dataAsset = Resources.Load(Path.GetFileNameWithoutExtension(TargetBinaryName)) as TextAsset;
        if (dataAsset == null)
        {
            Debug.LogError($"[GameLoader] Target binary '{TargetBinaryName}' not found in Resources.");
            return;
        }

        reader = new ByteReader(dataAsset.bytes, TargetBinaryName);
        StateMachine.AddTask(SM_Work);
    }

    private bool Error(string message)
    {
        Debug.LogError(message);
        return false;
    }

    private byte[] ExpectedSignature = new byte[] { 0x89, 0xFF, 0x0D, 0x0A, 0x1A, 0x0A };
    private byte[] EndChunkName = new byte[] { 0x45, 0x4E, 0x44, 0x00 };
    private byte[] ZstandardMagic = new byte[] { 0x28, 0xB5, 0x2F, 0xFD };

    private bool ByteMatch(byte[] a, byte[] b)
    {
        return a.AsSpan().SequenceEqual(b);
    }
    private bool ByteMatch(byte[] a, byte[] b, int count)
    {
        return a.AsSpan(0, count).SequenceEqual(b.AsSpan(0, count));
    }

    public static int ReverseTransformInt32(int value) => (value % 2 == 0) ? (value / 2) : (-(value + 1) / 2);

    public static byte[] DeinterleaveBytes(byte[] data, int valueSize)
    {
        if (data.Length % valueSize != 0)
            throw new ArgumentException("[GameLoader] Data length must be a multiple of value size.");
        int valueCount = data.Length / valueSize;
        byte[] deinterleaved = new byte[data.Length];
        for (int i = 0; i < valueCount; i++)
        {
            for (int byteIndex = 0; byteIndex < valueSize; byteIndex++)
            {
                deinterleaved[i * valueSize + byteIndex] = data[byteIndex * valueCount + i];
            }
        }
        return deinterleaved;
    }

    public static int[] ReadInterleavedI32(ByteReader br, uint count)
    {
        uint totalBytes = count * 4;
        byte[] data = br.ReadRange(totalBytes);
        byte[] deinterleaved = DeinterleaveBytes(data, 4);
        int[] values = new int[count];
        int last = 0;
        for (int i = 0; i < count; i++)
        {
            int b0 = deinterleaved[i * 4];
            int b1 = deinterleaved[i * 4 + 1];
            int b2 = deinterleaved[i * 4 + 2];
            int b3 = deinterleaved[i * 4 + 3];
            int value = (b0 << 24) | (b1 << 16) | (b2 << 8) | b3;
            if ((value & 0x80000000) != 0)
                value -= unchecked((int)0x100000000);
            value = ReverseTransformInt32(value);
            value += last;
            last = value;
            values[i] = value;
        }
        return values;
    }

    private struct ClassList
    {
        public ClassList(string nm, uint inst, int[] refer)
        {
            name = nm;
            instances = inst;
            referents = refer;
        }
        public string name;
        public uint instances;
        public int[] referents;
    }
    private class GLInstance
    {
        public GLInstance(string name)
        {
            className = name;
            properties = new Dictionary<string, object>();
            children = new List<uint>();
            parent = -1;
        }
        public string className;
        public Dictionary<string, object> properties;

        // to be autofilled by PRNT parsing
        public List<uint> children;
        public int parent;
    }
    private Dictionary<uint, ClassList> classIds = new Dictionary<uint, ClassList>();
    private Dictionary<uint, GLInstance> instances = new Dictionary<uint, GLInstance>();

    private void ParseINST(byte[] data)
    {
        ByteReader chunk = new ByteReader(data);
        uint classId = chunk.ReadUInt32();
        string name = chunk.ReadRangeStr(chunk.ReadUInt32());
        byte fmt = chunk.ReadByte();
        uint instCount = chunk.ReadUInt32();
        int[] ids = ReadInterleavedI32(chunk, instCount);

        print($"[GameLoader] Creating {instCount} instance{(instCount!=1?"s":"")} for classId {classId} ({name})");

        classIds.Add(classId, new ClassList(name, instCount, ids));

        foreach(uint id in ids)
        {
            instances.Add(id, new GLInstance(name));
        }
    }

    private Dictionary<byte, string> KnownValueNames = new Dictionary<byte, string>()
    {
        [0x01] = "String",
        [0x02] = "Bool",
        [0x03] = "Int32",
        [0x04] = "Float32",
        [0x05] = "Float64",
        [0x06] = "UDim",
        [0x07] = "UDim2",
        [0x08] = "Ray",
        [0x09] = "Faces",
        [0x0A] = "Axes",
        [0x0B] = "BrickColor",
        [0x0C] = "Color3",
        [0x0D] = "Vector2",
        [0x0E] = "Vector3",
        [0x10] = "CFrame",
        [0x12] = "Enum",
        [0x13] = "Referent",
        [0x14] = "Vector3int16",
        [0x15] = "NumberSequence",
        [0x16] = "ColorSequence",
        [0x17] = "NumberRange",
        [0x18] = "Rect",
        [0x19] = "PhysicalProperties",
        [0x1A] = "Color3uint8",
        [0x1B] = "Int64",
        [0x1C] = "SharedString",
        [0x1D] = "Bytecode",
        [0x1E] = "OptionalCoordinateFrame",
        [0x1F] = "UniqueId",
        [0x20] = "Font",
        [0x22] = "Content"
    };

    private object[] PROP_String(ByteReader chunk, uint o) { object[] li = new object[o]; for(uint i = 0; i < o; i++) { li[i] = chunk.ReadRangeStr(chunk.ReadUInt32()); } return li; }
    private object[] PROP_Bool(ByteReader chunk, uint o) { object[] li = new object[o]; for (uint i = 0; i < o; i++) { li[i] = chunk.ReadByte()==1; } return li; }
    private object[] PROP_Int32(ByteReader chunk, uint o) { return ReadInterleavedI32(chunk, o).Cast<object>().ToArray(); }
    private object[] PROP_Bytecode(ByteReader chunk, uint o) { object[] li = new object[o]; for (uint i = 0; i < o; i++) { li[i] = chunk.ReadRange(chunk.ReadUInt32()); } return li; }

    private void ParsePROP(byte[] data)
    {
        ByteReader chunk = new ByteReader(data);
        uint classId = chunk.ReadUInt32();
        string name = chunk.ReadRangeStr(chunk.ReadUInt32());
        byte fmt = chunk.ReadByte();

        string fmtName = KnownValueNames.ContainsKey(fmt) ? KnownValueNames[fmt] : "Unknown";
        uint instanceCount = classIds[classId].instances;
        uint valIndex = 0;
        object[] values;
        switch(fmt)
        {
            case 0x01:
                values = PROP_String(chunk, instanceCount);
                break;
            case 0x02:
                values = PROP_Bool(chunk, instanceCount);
                break;
            case 0x03:
                values = PROP_Int32(chunk, instanceCount);
                break;
            case 0x1D:
                values = PROP_Bytecode(chunk, instanceCount);
                break;
            default:
                Debug.LogWarning($"[GameLoader] Unsupported property type 0x{fmt.ToString("X2")} ({fmtName}) named '{name}'");
                values = new object[instanceCount];
                break;
        }
        foreach (uint referent in classIds[classId].referents)
        {
            instances[referent].properties.Add(name, values[valIndex]);
            valIndex++;
        }
    }

    private void ParsePRNT(byte[] data)
    {
        ByteReader chunk = new ByteReader(data);
        byte version = chunk.ReadByte();
        uint instanceCount = chunk.ReadUInt32();

        print("[GameLoader] Chaining together all instances...");

        int[] childIds = ReadInterleavedI32(chunk, instanceCount);
        int[] parentIds = ReadInterleavedI32(chunk, instanceCount);

        for(int i = 0; i < childIds.Length; i++)
        {
            uint childId = (uint)childIds[i];
            if(!instances.ContainsKey(childId))
            {
                Debug.LogWarning($"[GameLoader] Unknown referent ID: {childId}");
                continue;
            }
            int parentId = parentIds[i];
            instances[childId].parent = parentId;
            if(parentId != -1 && instances.ContainsKey((uint)parentId))
            {
                instances[(uint)parentId].children.Add(childId);
            }
        }
    }

    private bool State0_ParseInstances()
    {
        string magic = reader.ReadRangeStr(8);
        if (magic != "<roblox!")
            return Error($"[GameLoader] RBXL magic invalid: {magic}");
        if (!ByteMatch(reader.ReadRange(6), ExpectedSignature))
            return Error("[GameLoader] RBXL signature invalid.");

        ushort version = reader.ReadUInt16();
        print($"[GameLoader] RBXL Version: {version}");
        if (version != 0)
            Debug.LogWarning("[GameLoader] Version is non-zero, something might go wrong!");

        int chunks = reader.ReadInt32();
        int instances = reader.ReadInt32();
        reader.Skip(8);

        print($"[GameLoader] INST chunks: {chunks}");
        print($"[GameLoader] Instance count: {instances}");

        while(true)
        {
            byte[] chunkNameBytes = reader.ReadRange(4);
            if(ByteMatch(chunkNameBytes, EndChunkName))
            {
                print("[GameLoader] Reached END chunk, stopping chunk parsing.");
                break;
            }
            string chunkName = Encoding.UTF8.GetString(chunkNameBytes);
            uint compressedLength = reader.ReadUInt32();
            uint decodedLength = reader.ReadUInt32();
            reader.Skip(4);
            if(compressedLength == 0 && decodedLength == 0)
            {
                Debug.LogWarning($"[GameLoader] Ignoring chunk '{chunkName}' with no inner data.");
                continue;
            }
            byte[] decompressed = new byte[decodedLength];
            if(compressedLength != 0)
            {
                byte[] chunkData = reader.ReadRange(compressedLength);
                if(ByteMatch(chunkData, ZstandardMagic, 4))
                {
                    using var dctx = new ZstdSharp.Decompressor();
                    dctx.TryUnwrap(chunkData, decompressed, 0, out int written);
                } else
                {
                    unsafe
                    {
                        fixed (byte* ptr1 = chunkData)
                        {
                            fixed (byte* ptr2 = decompressed)
                            {
                                K4os.Compression.LZ4.LZ4Codec.Decode(ptr1, (int)compressedLength, ptr2, (int)decodedLength);
                            }
                        }
                    }
                }
            } else
            {
                decompressed = reader.ReadRange(decodedLength);
            }

            switch(chunkName)
            {
                case "INST":
                    {
                        ParseINST(decompressed);
                        break;
                    }
                case "PROP":
                    {
                        ParsePROP(decompressed);
                        break;
                    }
                case "PRNT":
                    {
                        ParsePRNT(decompressed);
                        break;
                    }
                default:
                    {
                        Debug.LogWarning($"[GameLoader] No parser exists for chunk type '{chunkName}'");
                        break;
                    }
            }
        }

        state = 1;
        print("All data loaded, converting to GameObjects...");

        return true;
    }

    private bool State1_CreateObjects()
    {
        foreach(GLInstance inst in instances.Values)
        {
            if (inst.parent == -1)
                RecurseObjectCreation(inst, DataModel, null);
        }
        state = 2;
        return true;
    }

    private static Dictionary<string, Type> IInstanceClasses = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a =>
            {
                Type[] types;
                try { types = a.GetTypes(); }
                catch { types = Array.Empty<Type>(); }
                return types;
            })
            .Where(t =>
                typeof(IInstance).IsAssignableFrom(t) &&
                typeof(MonoBehaviour).IsAssignableFrom(t)
            )
            .ToDictionary(t => t.Name, t => t);

    private void RecurseObjectCreation(GLInstance inst, Transform current, Instance current2 = null)
    {
        string objectName = (string)inst.properties["Name"];

        GameObject go = new GameObject();

        Instance usableParent = null;
        if(IInstanceClasses.TryGetValue(inst.className, out Type componentType))
        {
            Component comp = go.AddComponent(componentType);
            usableParent = comp as Instance;
            if (usableParent != null)
            {
                if(current2 != null)
                {
                    usableParent.Parent = current2;
                } else
                {
                    go.transform.SetParent(current);
                }
            } else
            {
                go.transform.SetParent(DataModel);
            }
            usableParent.OnInstantiate(inst.properties);
        } else
        {
            go.transform.name = objectName + " (Invalid)";
            go.transform.SetParent(current);
        }

        if (objectName != "maps") // Temporary removal to speed up testing
        {
            foreach (uint referent in inst.children)
            {
                RecurseObjectCreation(instances[referent], go.transform, usableParent);
            }
        }
    }

    private bool State2_InitGameState()
    {
        TaskScheduler.Enable();
        GameLoadCompleted.Invoke();
        return false;
    }

    // Return false when the task is finished
    private bool SM_Work(float deltaTime)
    {
        switch (state)
        {
            case 0:
                return State0_ParseInstances();
            case 1:
                LuauGlobals.Initialize();
                return State1_CreateObjects();
            case 2:
                return State2_InitGameState();
            default:
                break;
        }
        return false;
    }
}
