using System;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

using static LuauBytecodeTag;
using static LuauOpcode;

public enum VMLevel
{
    None,
    Plugin,
    CoreScript
}

public class Proto
{
    public byte nups;         // number of upvalues
    public byte numparams;
    public byte is_vararg;
    public byte maxstacksize;
    public byte flags;

    public object[] k;        // constants used by the function
    public uint[] code; // function bytecode
    public Proto[] p;         // functions defined inside the function

    public byte[] lineinfo;   // for each instruction, line number as a delta from baseline
    public int absoffset; // baseline line info, one entry for each 1<<linegaplog2 instructions; allocated after lineinfo
    // locvars, Uniblox has no plans to support Debug Info
    // upvalues, Uniblox has no plans to support Debug Info
    public string source;

    public string debugname;

    // typeinfo, unknown use

    // userdata, unused

    // gclist, unknown use

    public int sizecode;
    public int sizep;
    public int sizeupvalues;
    public int sizek;
    public int sizelineinfo;
    public int linegaplog2;
    public int linedefined;
    public int bytecodeid;
}

public class Closure
{
    public bool isC;
    public byte nupvalues;
    public byte stacksize;
    public bool preload;

    public Dictionary<string, object> env;

    public object[] upvals;
    public object[] uprefs;
    public Proto p;

    public object[] reg = new object[256];
    public int PC = 0;

    public bool returningFromClosureCall = false;
    public int returns = 0;
    public uint regstart = 0;

    public uint nextInst()
    {
        return p.code[PC++];
    }

    public Closure Clone()
    {
        var copy = new Closure
        {
            isC = this.isC,
            nupvalues = this.nupvalues,
            stacksize = this.stacksize,
            preload = this.preload,
            env = this.env,
            upvals = (object[])this.upvals.Clone(),
            uprefs = (object[])this.uprefs.Clone(),
            p = this.p,
            reg = (object[])this.reg.Clone(),
            PC = this.PC
        };
        return copy;
    }
}

public class FunctionExec
{
    public List<Closure> stack = new List<Closure>();
    public int stackPos = 0;

    public bool ReturningFromYield = false;
    public uint regstart = 0;
    public float waitTime = 0f;

    public FunctionExec(Closure initial)
    {
        stack.Add(initial);
    }
}

public class LuauVM
{
    private string[] stringTable;
    private Proto[] protos;
    private Dictionary<string, object> envt;
    private Closure mainCL;
    private Instance holder;

    // Read by off-class functions upon error to provide good stack traces in the Luau script
    public static FunctionExec currentStack;

    public readonly bool loaded = false;

    // All tasks should check this and immediately end if true.
    private bool disposed = false;

    private string readString(ByteReader br)
    {
        int id = br.ReadVariableLen();
        return id == 0 ? null : stringTable[id - 1];
    }

    public LuauVM(byte[] code, string name, Instance script)
    {
        ByteReader br = new ByteReader(code);
        //Debug.Log("LuauVM parsing...");

        envt = new Dictionary<string, object>(LuauGlobals.defaultEnvironment);
        envt.Add("script", script);

        byte version = br.ReadByte();
        byte typesversion = br.ReadByte();
        
        int stringCount = br.ReadVariableLen();
        stringTable = new string[stringCount];
        for(int i = 0; i < stringCount; i++)
        {
            string str = br.ReadRangeStr(br.ReadVariableLen());
            stringTable[i] = str;
        }

        if(typesversion == 3)
        {
            byte index = br.ReadByte();
            while (index != 0)
            {
                string str = br.ReadRangeStr(br.ReadVariableLen());
                index = br.ReadByte();
            }
        }

        int protoCount = br.ReadVariableLen();
        protos = new Proto[protoCount];
        for (int i = 0; i < protoCount; i++)
        {
            Proto p = new Proto();
            p.source = name;
            p.bytecodeid = i;

            p.maxstacksize = br.ReadByte();
            p.numparams = br.ReadByte();
            p.nups = br.ReadByte();
            p.is_vararg = br.ReadByte();

            if (version >= 4)
            {
                p.flags = br.ReadByte();
                if (typesversion >= 1 && typesversion <= 3)
                {
                    int typesize = br.ReadVariableLen();
                    br.Skip(typesize);
                }
            }

            int sizecode = br.ReadVariableLen();
            p.code = new uint[sizecode];
            p.sizecode = sizecode;

            for (int j = 0; j < p.sizecode; j++)
                p.code[j] = br.ReadUInt32();

            int sizek = br.ReadVariableLen();
            p.k = new object[sizek];
            p.sizek = sizek;

            for (int j = 0; j < p.sizek; j++)
                p.k[j] = null;

            for (int j = 0; j < p.sizek; j++)
            {
                switch((LuauBytecodeTag)br.ReadByte())
                {
                    case LBC_CONSTANT_NIL:
                        break;
                    case LBC_CONSTANT_BOOLEAN:
                        {
                            byte v = br.ReadByte();
                            p.k[j] = v == 1;
                            break;
                        }
                    case LBC_CONSTANT_NUMBER:
                        {
                            double v = BitConverter.ToDouble(br.ReadRange(8));
                            p.k[j] = v;
                            break;
                        }
                    case LBC_CONSTANT_VECTOR:
                        {
                            float x = BitConverter.ToSingle(br.ReadRange(4));
                            float y = BitConverter.ToSingle(br.ReadRange(4));
                            float z = BitConverter.ToSingle(br.ReadRange(4));
                            float w = BitConverter.ToSingle(br.ReadRange(4));
                            p.k[j] = new Vector4(x, y, z, w);
                            break;
                        }
                    case LBC_CONSTANT_STRING:
                        {
                            string v = readString(br);
                            p.k[j] = v;
                            break;
                        }
                    case LBC_CONSTANT_IMPORT:
                        {
                            uint aux = br.ReadUInt32();
                            string[] chain = Luau.AuxToImportChain(p, aux);
                            p.k[j] = Luau.ResolveImport(p, 0, chain, envt);
                            break;
                        }
                    case LBC_CONSTANT_TABLE:
                        {
                            int keys = br.ReadVariableLen();
                            Dictionary<string, object> h = new Dictionary<string, object>();
                            for (int k = 0; k < keys; k++)
                            {
                                int temp = br.ReadVariableLen();
                                h.Add((string)p.k[temp], null);
                            }
                            p.k[j] = h;
                            break;
                        }
                    case LBC_CONSTANT_CLOSURE:
                        {
                            int fid = br.ReadVariableLen();
                            Proto target = protos[fid];
                            Closure cl = luaF.newLclosure(target.nups, envt, target);
                            cl.preload = cl.nupvalues > 0;
                            p.k[j] = cl;
                            break;
                        }
                }
            }

            int sizep = br.ReadVariableLen();
            p.p = new Proto[sizep];
            p.sizep = sizep;
            for(int j = 0; j < p.sizep; j++)
            {
                int fid = br.ReadVariableLen();
                p.p[j] = protos[fid];
            }

            p.linedefined = br.ReadVariableLen();
            p.debugname = readString(br);
            if (p.debugname == null)
                p.debugname = "anon_" + p.bytecodeid;

            byte lineinfo = br.ReadByte();

            if(lineinfo != 0)
            {
                p.linegaplog2 = br.ReadByte();
                int intervals = ((p.sizecode - 1) >> p.linegaplog2) + 1;
                int absoffset = (p.sizecode + 3) & ~3;

                int sizelineinfo = absoffset + intervals * sizeof(int);
                p.lineinfo = new byte[sizelineinfo];
                p.sizelineinfo = sizelineinfo;

                p.absoffset = absoffset;

                byte lastoffset = 0;
                for (int j = 0; j < p.sizecode; j++)
                {
                    lastoffset += br.ReadByte();
                    p.lineinfo[j] = lastoffset;
                }

                int lastline = 0;
                for (int j = 0; j < intervals; j++)
                {
                    lastline += br.ReadInt32();
                    BitConverter.GetBytes(lastline).CopyTo(p.lineinfo, absoffset + j * 4);
                }
            }

            byte debuginfo = br.ReadByte();

            if (debuginfo != 0)
            {
                Debug.LogWarning("Bytecode should not have debug info! It is unsupported!");

                // Skip debug info so scripts still function
                int sizelocvars = br.ReadVariableLen();
                for(int j = 0; j < sizelocvars; j++)
                {
                    readString(br);
                    br.ReadVariableLen();
                    br.ReadVariableLen();
                    br.Skip(1);
                }
                int sizeupvalues = br.ReadVariableLen();
                for (int j = 0; j < sizeupvalues; j++)
                {
                    readString(br);
                }
            }

            protos[i] = p;
        }

        int mainid = br.ReadVariableLen();
        Proto main = protos[mainid];

        main.debugname = "(root code)";

        Closure cl2 = luaF.newLclosure(0, envt, main);
        mainCL = cl2;

        TaskScheduler.AddTask(new Task(StepTask, TaskRuntime.Heartbeat, new FunctionExec(cl2)));

        loaded = true;
    }

    private TaskRuntime StepTask(float delta, object context, Task self)
    {
        if (disposed)
            return TaskRuntime.Ended;

        FunctionExec exec = (FunctionExec)context;
        currentStack = exec;
        Closure current = exec.stack[exec.stackPos];
        Proto proto = current.p;

        if(exec.ReturningFromYield)
        {
            exec.ReturningFromYield = false;
            current.reg[exec.regstart] = Time.realtimeSinceStartup - exec.waitTime;
        }

        while(true)
        {
            uint Instruction = current.nextInst();
            LuauOpcode opcode = (LuauOpcode)Luau.INSN_OP(Instruction);
            Debug.Log(opcode);
            switch(opcode)
            {
                // Silent ignore cases
                case LOP_NOP:
                case LOP_BREAK:
                    break;

                // Verbose ignore cases (because it should probably be supported in the future)
                case LOP_PREPVARARGS:
                    Debug.LogWarning($"Ignored opcode: {opcode}");
                    break;

                case LOP_CALL:
                    {
                        uint start = Luau.INSN_A(Instruction);
                        object toCall = current.reg[start];
                        int args = (int)Luau.INSN_B(Instruction) - 1;
                        int returns = (int)Luau.INSN_C(Instruction) - 1;

                        if(toCall is PcallStub)
                        {
                            // TODO, support pcall
                            current.reg[start] = true;
                            toCall = current.reg[start + 1];
                            returns--;
                            start++;
                        }

                        if(toCall is TaskFunction tf)
                        {
                            object[] arg = new object[args];
                            for (int i = 0; i < args - 1; i++)
                            {
                                arg[i] = current.reg[start + i + 2];
                            }
                            TaskInstruction inst = tf(arg);
                            switch(inst.action)
                            {
                                case TaskAction.Wait:
                                    self.Yield(inst);
                                    exec.ReturningFromYield = true;
                                    exec.regstart = start;
                                    exec.waitTime = inst.relatedTime;
                                    return TaskRuntime.Unchanged;
                            }
                        }
                        else if (toCall is ImmediateFunctionWrapSrc lf)
                        {
                            object inst = current.reg[start + 1];
                            object[] fargs = new object[0];
                            if(args >= 2)
                            {
                                fargs = new object[args - 1];
                                for(int i = 0; i < args - 1; i++)
                                {
                                    fargs[i] = current.reg[start + i + 2];
                                }
                            }
                            object[] ret = lf(inst, fargs);
                            for(int i = 0; i < Math.Min(ret.Length, returns); i++)
                            {
                                current.reg[start + i] = ret[i];
                            }
                        } else if(toCall is Closure cl)
                        {
                            //Luau.DetailedError($"VM Error: To-do, support Closure calls", exec);
                            for(int i = 0; i < Math.Min(args, cl.p.numparams); i++)
                            {
                                cl.reg[i] = current.reg[start + i + 1];
                            }
                            Debug.Log($"Jumping into {cl.p.debugname}");
                            exec.stack.Add(cl);
                            exec.stackPos++;
                            current.returningFromClosureCall = true;
                            current.returns = returns;
                            current.regstart = start;

                            current = exec.stack[exec.stackPos];
                            proto = current.p;
                        } else
                        {
                            Luau.DetailedError($"Luau Error: attempt to call a {(toCall == null ? "nil" : toCall.GetType().Name)} value", exec);
                        }
                    }
                    break;
                case LOP_DUPCLOSURE:
                    current.reg[Luau.INSN_A(Instruction)] = ((Closure)proto.k[Luau.INSN_D(Instruction)]).Clone();
                    break;
                case LOP_GETIMPORT:
                    {
                        uint aux = current.nextInst();
                        string[] chain = Luau.AuxToImportChain(proto, aux);
                        object imp = Luau.ResolveImport(proto, Instruction, chain, envt);
                        if(imp == null)
                            Luau.DetailedError($"VM Error: ResolveImport returned null at runtime: '{string.Join('.',chain)}'", exec);
                        current.reg[Luau.INSN_A(Instruction)] = imp;
                    }
                    break;
                case LOP_JUMP:
                case LOP_JUMPBACK:
                    current.PC += Luau.INSN_D(Instruction);
                    break;
                case LOP_JUMPIF:
                    if (Luau.LIKELY(current.reg[Luau.INSN_A(Instruction)]))
                        current.PC += Luau.INSN_D(Instruction);
                    break;
                case LOP_JUMPIFNOT:
                    if (!Luau.LIKELY(current.reg[Luau.INSN_A(Instruction)]))
                        current.PC += Luau.INSN_D(Instruction);
                    break;
                case LOP_LOADB:
                    current.reg[Luau.INSN_A(Instruction)] = Luau.INSN_B(Instruction) == 1;
                    current.PC += (int)Luau.INSN_C(Instruction);
                    break;
                case LOP_LOADK:
                    current.reg[Luau.INSN_A(Instruction)] = proto.k[Luau.INSN_D(Instruction)]; break;
                case LOP_LOADN:
                    current.reg[Luau.INSN_A(Instruction)] = (double)Luau.INSN_D(Instruction);
                    break;
                case LOP_LOADNIL:
                    current.reg[Luau.INSN_A(Instruction)] = null;
                    break;
                case LOP_NAMECALL:
                    {
                        object source = current.reg[Luau.INSN_B(Instruction)];
                        string key = (string)proto.k[current.nextInst()];
                        if (source == null) Luau.DetailedError($"Luau Error: attempt to index nil with '{key}'", exec);
                        if(!(source is IIndexable indexable)) Luau.DetailedError($"Luau Error: attempt to index {source.GetType().Name} with '{key}'", exec);
                        uint A = Luau.INSN_A(Instruction);
                        current.reg[A] = Indexer.Namecall_ToFunction(source, key);
                        current.reg[A + 1] = source;
                    }
                    break;
                case LOP_RETURN:
                    {
                        uint start = Luau.INSN_A(Instruction);
                        int ret = (int)Luau.INSN_B(Instruction)-1;
                        Closure sendback = exec.stack[exec.stackPos-1];
                        for (int i = 0; i < Math.Min(ret, sendback.returns); i++)
                            sendback.reg[sendback.regstart + i] = current.reg[start + i];

                        Debug.Log($"Jumping back to {sendback.p.debugname}");
                        exec.stack.RemoveAt(exec.stackPos);
                        exec.stackPos--;

                        current = exec.stack[exec.stackPos];
                        proto = current.p;
                    }
                    break;
                default:
                    Luau.DetailedError($"VM Error: Unknown opcode: {opcode}", exec);
                    break;
            }
        }

        return TaskRuntime.Unchanged;
    }

    public void Dispose()
    {

    }
}