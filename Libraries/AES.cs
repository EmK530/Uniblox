using System;
using System.IO;
using System.Security.Cryptography;

public struct AESKey
{
    public byte[] PartA;
    public byte[] PartB;
    public AESKey(byte[] b1, byte[] b2)
    {
        PartA = b1;
        PartB = b2;
    }
}

public static class AES
{
    public static byte[] Encrypt(byte[] data, byte[] key)
    {
        if (key.Length != 32)
            throw new ArgumentException("[AES.Encrypt] Key is not 32 bytes");
        using var aes = new AesManaged();
        aes.Key = key;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.GenerateIV();
        using var ms = new MemoryStream();
        ms.Write(aes.IV, 0, aes.IV.Length);
        using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
        {
            cs.Write(data, 0, data.Length);
        }
        byte[] cipherWithIV = ms.ToArray();
        using var hmac = new HMACSHA256(key);
        byte[] tag = hmac.ComputeHash(cipherWithIV);
        byte[] output = new byte[cipherWithIV.Length + tag.Length];
        Buffer.BlockCopy(cipherWithIV, 0, output, 0, cipherWithIV.Length);
        Buffer.BlockCopy(tag, 0, output, cipherWithIV.Length, tag.Length);
        return output;
    }

    public static byte[] Decrypt(byte[] data, byte[] key)
    {
        if (key.Length != 32)
            throw new ArgumentException("[AES.Decrypt] Key is not 32 bytes");
        if (data.Length < 16 + 32)
            throw new ArgumentException("[AES.Decrypt] Encrypted data is not valid");
        byte[] cipherWithIV = new byte[data.Length - 32];
        byte[] tag = new byte[32];
        Buffer.BlockCopy(data, 0, cipherWithIV, 0, cipherWithIV.Length);
        Buffer.BlockCopy(data, cipherWithIV.Length, tag, 0, tag.Length);
        using var hmac = new HMACSHA256(key);
        byte[] expectedTag = hmac.ComputeHash(cipherWithIV);
        if (!CryptographicOperations.FixedTimeEquals(tag, expectedTag))
            throw new CryptographicException("[AES.Decrypt] Cannot decrypt, HMAC validation failed");
        byte[] iv = new byte[16];
        Buffer.BlockCopy(cipherWithIV, 0, iv, 0, iv.Length);
        byte[] cipher = new byte[cipherWithIV.Length - iv.Length];
        Buffer.BlockCopy(cipherWithIV, iv.Length, cipher, 0, cipher.Length);
        using var aes = new AesManaged();
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        using var msPlain = new MemoryStream();
        using (var cs = new CryptoStream(new MemoryStream(cipher), aes.CreateDecryptor(), CryptoStreamMode.Read))
        {
            cs.CopyTo(msPlain);
        }
        return msPlain.ToArray();
    }

    /*
    public static void CreateNewKey()
    {
        byte[] key = new byte[32];
        RandomNumberGenerator.Fill(key);
        byte[] partA = new byte[32];
        byte[] partB = new byte[32];
        RandomNumberGenerator.Fill(partA);
        for (int i = 0; i < 32; i++)
            partB[i] = (byte)(partA[i] ^ key[i]);
        Console.WriteLine("PartA: " + string.Join(",", partA));
        Console.WriteLine("PartB: " + string.Join(",", partB));
    }
    */

    public static byte[] GetKey(AESKey key)
    {
        byte[] baseKey = new byte[32];
        for (int i = 0; i < 32; i++)
            baseKey[i] = (byte)(key.PartA[i] ^ key.PartB[i]);
        return baseKey;
    }
}