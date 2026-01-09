using System.Diagnostics;
using System.IO;
using UnityEngine;

public static class ScriptCompiler
{
    private static string TempDirectory = Path.GetTempPath();

    public static byte[] Compile(string source, string cacheIdent = "script_cache")
    {
        string scriptHash = XXHash64.HashString(source).ToString("x8");
        string cacheDir = Path.Combine(Application.streamingAssetsPath, cacheIdent);
        if(!Directory.Exists(cacheDir))
            Directory.CreateDirectory(cacheDir);
        string scriptPath = Path.Combine(cacheDir, $"{scriptHash}.bin");
        if (File.Exists(scriptPath))
            return AES.Decrypt(File.ReadAllBytes(scriptPath), AES.GetKey(InternalConfig.ScriptCacheKey));

        if (!File.Exists(InternalConfig.TargetCompiler))
        {
            UnityEngine.Debug.LogError("[ScriptCompiler] Cannot find luau-compile.exe in StreamingAssets.");
            return null;
        }
        
        // Dumping raw scripts to disk temporarily is not safe, packaging RBXLs with pre-compiled bytecode is a safer approach.
        string inputPath = Path.Combine(TempDirectory, $"Uniblox-{scriptHash}");
        string outputPath = Path.Combine(cacheDir, $"{scriptHash}.luauc");

        File.WriteAllText(inputPath, source);

        Process compile = new Process()
        {
            StartInfo =
            {
                FileName = Path.Combine(Application.streamingAssetsPath, "luau-compile.exe"),
                Arguments = $"--binary {InternalConfig.CompilerFlags} \"{inputPath}\"",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };

        compile.Start();

        using var memoryStream = new MemoryStream();
        byte[] buffer = new byte[4096];
        int bytesRead;
        while ((bytesRead = compile.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            memoryStream.Write(buffer, 0, bytesRead);
        }

        compile.WaitForExit();

        File.Delete(inputPath);

        byte[] compiledData = memoryStream.ToArray();
        byte[] keyBytes = AES.GetKey(InternalConfig.ScriptCacheKey);
        byte[] dataToBeCached = AES.Encrypt(compiledData, keyBytes);

        File.WriteAllBytes(outputPath, dataToBeCached);

        UnityEngine.Debug.Log($"Compiled a script: {scriptHash}.luauc");
        return compiledData;
    }
}