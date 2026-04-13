using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InternalConfig
{
    public static string TargetCompiler = Path.Combine(Application.streamingAssetsPath, "luau-compile.exe");
    public static string CompilerFlags = "-O2 -g1";
    public static int AutoPPUBaseResolution = 540;

    // Used automatically by ByteReader
    public static Dictionary<string, AESKey> EncryptedAssetKeys = new Dictionary<string, AESKey>()
    {
        ["content-g1.bytes"] = new AESKey(
            new byte[] { 57, 101, 94, 162, 68, 198, 106, 98, 37, 90, 6, 206, 12, 121, 74, 178, 146, 67, 244, 46, 48, 214, 47, 119, 227, 177, 44, 91, 236, 148, 219, 166 },
            new byte[] { 7, 161, 106, 178, 154, 157, 21, 116, 173, 180, 230, 116, 12, 128, 81, 109, 87, 114, 213, 192, 162, 77, 48, 241, 69, 229, 245, 17, 120, 55, 50, 158 }
        ),
        ["content-g2.bytes"] = new AESKey(
            new byte[] { 57, 101, 94, 162, 68, 198, 106, 98, 37, 90, 6, 206, 12, 121, 74, 178, 146, 67, 244, 46, 48, 214, 47, 119, 227, 177, 44, 91, 236, 148, 219, 166 },
            new byte[] { 7, 161, 106, 178, 154, 157, 21, 116, 173, 180, 230, 116, 12, 128, 81, 109, 87, 114, 213, 192, 162, 77, 48, 241, 69, 229, 245, 17, 120, 55, 50, 158 }
        )
    };

    public static AESKey ScriptCacheKey = new AESKey(
        new byte[] { 165,25,47,170,232,79,254,122,90,140,142,205,202,8,100,86,253,140,32,83,194,169,8,194,155,243,187,148,82,53,236,226 },
        new byte[] { 76,160,190,134,114,254,61,163,181,68,207,163,122,219,60,83,145,110,128,64,138,3,102,173,163,155,132,107,163,138,129,198 }
    );
}