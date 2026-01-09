using System;
using System.Text;

public static class XXHash32
{
    private const uint PRIME32_1 = 0x9E3779B1u;
    private const uint PRIME32_2 = 0x85EBCA77u;
    private const uint PRIME32_3 = 0xC2B2AE3Du;
    private const uint PRIME32_4 = 0x27D4EB2Fu;
    private const uint PRIME32_5 = 0x165667B1u;

    public static uint HashString(string text, uint seed = 0)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        return HashBytes(bytes, seed);
    }

    public static uint HashBytes(byte[] data, uint seed = 0)
    {
        int len = data.Length;
        int idx = 0;
        uint hash;

        if (len >= 16)
        {
            uint v1 = seed + PRIME32_1 + PRIME32_2;
            uint v2 = seed + PRIME32_2;
            uint v3 = seed + 0;
            uint v4 = seed - PRIME32_1;

            int limit = len - 16;

            while (idx <= limit)
            {
                v1 = Round(v1, BitConverter.ToUInt32(data, idx)); idx += 4;
                v2 = Round(v2, BitConverter.ToUInt32(data, idx)); idx += 4;
                v3 = Round(v3, BitConverter.ToUInt32(data, idx)); idx += 4;
                v4 = Round(v4, BitConverter.ToUInt32(data, idx)); idx += 4;
            }

            hash = RotateLeft(v1, 1) +
                   RotateLeft(v2, 7) +
                   RotateLeft(v3, 12) +
                   RotateLeft(v4, 18);
        }
        else
        {
            hash = seed + PRIME32_5;
        }

        hash += (uint)len;

        while (idx + 4 <= len)
        {
            uint k1 = BitConverter.ToUInt32(data, idx);
            hash ^= Round(0, k1);
            hash = RotateLeft(hash, 17) * PRIME32_4;
            idx += 4;
        }

        while (idx < len)
        {
            hash ^= data[idx] * PRIME32_5;
            hash = RotateLeft(hash, 11) * PRIME32_1;
            idx++;
        }

        hash ^= hash >> 15;
        hash *= PRIME32_2;
        hash ^= hash >> 13;
        hash *= PRIME32_3;
        hash ^= hash >> 16;

        return hash;
    }

    private static uint Round(uint acc, uint input)
    {
        acc += input * PRIME32_2;
        acc = RotateLeft(acc, 13);
        acc *= PRIME32_1;
        return acc;
    }

    private static uint RotateLeft(uint value, int count)
    {
        return (value << count) | (value >> (32 - count));
    }
}

public static class XXHash64
{
    private const ulong PRIME64_1 = 11400714785074694791UL;
    private const ulong PRIME64_2 = 14029467366897019727UL;
    private const ulong PRIME64_3 = 1609587929392839161UL;
    private const ulong PRIME64_4 = 9650029242287828579UL;
    private const ulong PRIME64_5 = 2870177450012600261UL;

    public static ulong Hash(byte[] data, ulong seed = 0)
    {
        int len = data.Length;
        int index = 0;
        ulong hash;

        if (len >= 32)
        {
            ulong v1 = seed + PRIME64_1 + PRIME64_2;
            ulong v2 = seed + PRIME64_2;
            ulong v3 = seed + 0;
            ulong v4 = seed - PRIME64_1;

            while (index <= len - 32)
            {
                v1 = Round(v1, BitConverter.ToUInt64(data, index)); index += 8;
                v2 = Round(v2, BitConverter.ToUInt64(data, index)); index += 8;
                v3 = Round(v3, BitConverter.ToUInt64(data, index)); index += 8;
                v4 = Round(v4, BitConverter.ToUInt64(data, index)); index += 8;
            }

            hash = RotateLeft(v1, 1) + RotateLeft(v2, 7) +
                   RotateLeft(v3, 12) + RotateLeft(v4, 18);

            hash = MergeRound(hash, v1);
            hash = MergeRound(hash, v2);
            hash = MergeRound(hash, v3);
            hash = MergeRound(hash, v4);
        }
        else
        {
            hash = seed + PRIME64_5;
        }

        hash += (ulong)len;

        while (index <= len - 8)
        {
            ulong k1 = Round(0, BitConverter.ToUInt64(data, index));
            hash ^= k1;
            hash = RotateLeft(hash, 27) * PRIME64_1 + PRIME64_4;
            index += 8;
        }

        while (index < len)
        {
            hash ^= (ulong)data[index] * PRIME64_5;
            hash = RotateLeft(hash, 11) * PRIME64_1;
            index++;
        }

        hash ^= hash >> 33;
        hash *= PRIME64_2;
        hash ^= hash >> 29;
        hash *= PRIME64_3;
        hash ^= hash >> 32;

        return hash;
    }

    public static ulong HashString(string text, ulong seed = 0)
        => Hash(Encoding.UTF8.GetBytes(text), seed);

    public static string ToHex(ulong value)
        => value.ToString("X16");

    private static ulong Round(ulong acc, ulong input)
    {
        acc += input * PRIME64_2;
        acc = RotateLeft(acc, 31);
        acc *= PRIME64_1;
        return acc;
    }

    private static ulong MergeRound(ulong acc, ulong val)
    {
        val = Round(0, val);
        acc ^= val;
        acc = acc * PRIME64_1 + PRIME64_4;
        return acc;
    }

    private static ulong RotateLeft(ulong value, int count)
        => (value << count) | (value >> (64 - count));
}