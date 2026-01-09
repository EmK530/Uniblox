using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InternalConfig
{
    public static string TargetCompiler = Path.Combine(Application.streamingAssetsPath, "luau-compile.exe");
    public static string CompilerFlags = "-O2 -g1";

    // Used automatically by ByteReader

    // DO NOT UNREDACT THESE KEYS WHEN COMMITTING
    public static Dictionary<string, AESKey> EncryptedAssetKeys = new Dictionary<string, AESKey>()
    {
        ["content-g1.bytes"] = new AESKey(
            new byte[] { },
            new byte[] { }
        ),
        ["content-g2.bytes"] = new AESKey(
            new byte[] { },
            new byte[] { }
        )
    };

    public static AESKey ScriptCacheKey = new AESKey(
        new byte[] { },
        new byte[] { }
    );
}