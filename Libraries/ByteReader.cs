using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class ByteReader
{
    private readonly IEnumerator<byte> source;

    public ByteReader(byte[] data)
    {
        source = data.Cast<byte>().GetEnumerator();
    }

    public ByteReader(byte[] data, string baseName)
    {
        if (InternalConfig.EncryptedAssetKeys.TryGetValue(baseName, out AESKey AESKey))
        {
            byte[] aesKeyBytes = AES.GetKey(AESKey);
            data = AES.Decrypt(data, aesKeyBytes);
        }
        source = data.Cast<byte>().GetEnumerator();
    }

    public ByteReader(string filePath)
    {
        string fileName = Path.GetFileName(filePath);
        byte[] data = File.ReadAllBytes(filePath);
        if (InternalConfig.EncryptedAssetKeys.TryGetValue(fileName, out AESKey AESKey))
        {
            byte[] aesKeyBytes = AES.GetKey(AESKey);
            data = AES.Decrypt(data, aesKeyBytes);
        }
        source = data.Cast<byte>().GetEnumerator();
    }

    private byte NextByte()
    {
        if (!source.MoveNext())
        {
            UnityEngine.Debug.LogWarning("Something tried to read beyond the end of the enumerator.");
            return 0;
        }

        return source.Current;
    }

    public void Skip(int count)
    {
        for (int i = 0; i < count; i++)
            NextByte();
    }

    public byte ReadByte() => NextByte();

    public ushort ReadUInt16(Endian e = Endian.Little)
    {
        switch (e)
        {
            case Endian.Little:
                return (ushort)(ReadByte() + (ReadByte() << 8));
            case Endian.Big:
                return (ushort)((ReadByte() << 8) + ReadByte());
        }

        UnityEngine.Debug.LogWarning($"ReadUInt16 received an invalid endian ID: {(int)e}");
        return 0;
    }

    public short ReadInt16(Endian e = Endian.Little)
    {
        ushort value = ReadUInt16(e);
        return (short)value;
    }

    public uint ReadUInt32(Endian e = Endian.Little)
    {
        switch (e)
        {
            case Endian.Little:
                return (uint)(
                    ReadByte() +
                    (ReadByte() << 8) +
                    (ReadByte() << 16) +
                    (ReadByte() << 24)
                );
            case Endian.Big:
                return (uint)(
                    (ReadByte() << 24) +
                    (ReadByte() << 16) +
                    (ReadByte() << 8) +
                    ReadByte()
                );
        }

        UnityEngine.Debug.LogWarning($"ReadUInt32 received an invalid endian ID: {(uint)e}");
        return 0;
    }

    public int ReadInt32(Endian e = Endian.Little)
    {
        uint value = ReadUInt32(e);
        return (int)value;
    }

    public byte[] ReadRange(uint count)
    {
        byte[] buf = new byte[count];
        for (uint i = 0; i < count; i++)
            buf[i] = ReadByte();
        return buf;
    }

    public string ReadRangeStr(uint count)
    {
        char[] buf = new char[count];
        for (uint i = 0; i < count; i++)
            buf[i] = (char)ReadByte();
        return new string(buf);
    }
    public string ReadRangeStr(int count)
    {
        return ReadRangeStr((uint)count);
    }

    public int ReadVariableLen()
    {
        int result = 0;
        int shift = 0;

        while (true)
        {
            byte b = ReadByte();
            result |= (b & 127) << shift;
            shift += 7;

            if ((b & 128) == 0)
                break;
        }

        return result;
    }
}

public enum Endian
{
    Little = 0,
    Big = 1
}