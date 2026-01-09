using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public static class Luau
{
    public static uint INSN_OP(uint insn) => insn & 0xFF;
    public static uint INSN_A(uint insn) => (insn >> 8) & 0xFF;
    public static uint INSN_B(uint insn) => (insn >> 16) & 0xFF;
    public static uint INSN_C(uint insn) => (insn >> 24) & 0xFF;
    public static int INSN_D(uint insn) => (int)((int)insn >> 16);
    public static int INSN_E(uint insn) => (int)(insn >> 8);

    private static int GetAbsLineInfo(Proto p, int interval)
    {
        if (p.absoffset == 0)
            return 0;
        int index = p.absoffset + interval * 4;
        return BitConverter.ToInt32(p.lineinfo, index);
    }

    private static int GetLine(Proto p, int ip)
    {
        if (p.lineinfo == null || p.sizelineinfo == 0)
            return 0;
        int interval = ip >> p.linegaplog2;
        int absline = GetAbsLineInfo(p, interval);
        int start = interval << p.linegaplog2;
        int delta = p.lineinfo[ip];
        if (start > 0)
            delta -= p.lineinfo[start - 1];
        return absline + delta;
    }

    public static object CreateLuauCallableFunction(MethodInfo mi)
    {
        Type t = mi.ReturnType;

        if (t == typeof(object[]))
        {
            return new ImmediateFunctionWrapSrc((obj, args) =>
            {
                try
                {
                    return (object[])mi.Invoke(obj, new object[] { args });
                }
                catch (TargetInvocationException tie)
                {
                    throw new Exception(
                        $"(ImmediateFunction Error) {tie.InnerException.Message}\n\n{tie.InnerException.StackTrace}"
                    );
                }
            });
        }
        else if (typeof(IEnumerator).IsAssignableFrom(t))
        {
            return new AsyncFunctionWrapSrc((vm, obj, args) =>
            {

                return (IEnumerator)mi.Invoke(obj, new object[] { vm, args });
            });
        }
        else
        {
            throw new Exception($"LuauCallable method '{mi.Name}' has an invalid return type '{t}'.");
        }
    }

    public static void DetailedError(string reason)
    {
        DetailedError(reason, LuauVM.currentStack);
    }
    public static void DetailedError(string reason, FunctionExec stack)
    {
        string fullError = "\n" + reason;
        for(int i = stack.stack.Count; i > 0; i--)
        {
            Closure cl = stack.stack[i - 1];
            fullError += $"\n  {cl.p.source} : {cl.p.debugname} : {GetLine(cl.p,cl.PC)}";
        }
        throw new Exception(fullError);
    }

    public static void ValueError(string function, string expected, int arg, object received)
    {
        DetailedError($"Luau Error: invalid argument #{arg} to '{function}' ({expected} expected, got {received?.GetType().Name ?? "nil"})");
    }

    public static string[] AuxToImportChain(Proto p, uint aux)
    {
        int pathLength = (int)(aux >> 30);
        List<string> importPathParts = new List<string>();
        for (int a = 0; a < pathLength; a++)
        {
            int shiftAmount = 10 * a;
            int index = (int)((aux >> (20 - shiftAmount)) & 1023);
            if (index >= p.k.Length)
            {
                throw new Exception($"[AuxToImportChain] Invalid constant index {index}.");
            }
            else
            {
                importPathParts.Add(p.k[index].ToString());
            }
        }
        return importPathParts.ToArray();
    }

    public static object ResolveImport(Proto p, uint inst, string[] chain, Dictionary<string, object>? customEnvt)
    {
        if (inst != 0)
        {
            return p.k[INSN_D(inst)];
            //object fastGet = p.k[Luau.INSN_D(inst)];
            //if (fastGet != null)
                //return fastGet;
        }

        if(customEnvt == null)
            customEnvt = LuauGlobals.defaultEnvironment;

        object current = null;
        int i = 0;
        foreach (string part in chain)
        {
            i++;
            if (i == 1)
            {
                if (customEnvt.TryGetValue(part, out object v))
                {
                    current = v;
                    continue;
                }
                else
                {
                    UnityEngine.Debug.LogWarning($"ResolveImport could not find the global '{part}'");
                    return null;
                }
            }

            if (current == null)
            {
                UnityEngine.Debug.LogWarning($"ResolveImport failed to resolve '{string.Join('.', chain)}' as the part before '{part}' was null");
                return null;
            }

            object found = Indexer.UniversalIndex(current, part, true);
            if (found != null)
            {
                current = found;
            }
            else
            {
                UnityEngine.Debug.LogWarning($"ResolveImport could not find the part '{part}' in the chain '{string.Join('.', chain)}'");
                return null;
            }
        }
        return current;
    }

    public static bool LIKELY(object v1)
    {
        if (v1 == null)
            return false;
        Type t = v1.GetType();
        if (t == typeof(bool))
        {
            return (bool)v1;
        }
        return true;
    }

    public static object CreateLuauTable_FromDictionary(Dictionary<string, object> dict)
    {
        // TODO: Implement proper Luau table behavior
        return dict;
    }
}

public static class luaF
{
    public static Closure newLclosure(int nelems, Dictionary<string,object> e, Proto p)
    {
        Closure c = new Closure();
        c.isC = false;
        c.env = e;
        c.nupvalues = (byte)nelems;
        c.stacksize = p.maxstacksize;
        c.preload = false;
        c.p = p;
        c.upvals = new object[nelems];
        c.uprefs = new object[nelems];
        for(int i = 0; i < nelems; i++)
        {
            c.upvals[i] = null;
            c.uprefs[i] = null;
        }
        return c;
    }
}