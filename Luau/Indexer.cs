using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Indexer
{
    public static object GetInstanceChild(object source, string key)
    {
        // 1. Instance child lookup
        if (source is IInstance inst)
        {
            Instance Isource = (Instance)source;
            Transform find = Isource.transform.Find(key);
            
        }
        return null;
    }

    public static object Namecall_ToFunction(object source, string key)
    {
        Type t = source.GetType();
        MethodInfo method = t.GetMethod("_"+key, BindingFlags.Instance | BindingFlags.Public);
        if (method == null)
            Luau.DetailedError($"Luau Error: attempt to call missing method '{key}' of {t.Name}{((source is IInstance) ? $" \"{((Instance)source).Name}\"" : "")}");
        if (method.GetCustomAttribute<LuauCallable>() == null)
            Luau.DetailedError($"VM Error: The method '{key}' of {t.Name} is not callable by Uniblox (mark it as LuauCallable)");
        if (method.GetCustomAttribute<RobloxScriptSecurity>() != null)
            Luau.DetailedError($"Luau Error: The current thread cannot read '{key}' (lacking capability RobloxScript)");
        return Luau.CreateLuauCallableFunction(method);
    }

    private static object InternalIndexChildren(Instance source, string key, bool import = false)
    {
        Transform find = source.transform.Find(key);
        if(find != null)
        {
            Component comp = find.gameObject.GetComponent(typeof(Instance));
            if(comp != null)
            {
                return (Instance)comp;
            }
        }
        if(!import)
            Luau.DetailedError($"Luau Error: '{key}' is not a valid member of {source.GetType().Name}{$" \"{source.Name}\""}");
        return null;
    }

    public static object UniversalIndex(object source, string key, bool import = false)
    {
        var t = source as Type ?? source.GetType();
        if (t.IsEnum)
        {
            var enumField = t.GetField(key, BindingFlags.Public | BindingFlags.Static);
            if (enumField != null)
            {
                return enumField.GetValue(null);
            }
            if (!import)
                Luau.DetailedError($"Luau Error: The current thread cannot read property '{key}'");
            return null;
        }
        if (source is Dictionary<string, object> dict)
        {
            if (!dict.TryGetValue(key, out source))
            {
                return null;
            }
            return source;
        }
        else
        {
            var prop = t.GetProperty(key, BindingFlags.Instance | BindingFlags.Public);
            if (prop != null)
            {
                if (prop.GetCustomAttribute<Hidden>() != null)
                {
                    if (!import)
                        Luau.DetailedError($"Luau Error: '{key}' is not a valid member of {source}");
                    return null;
                }
                if (prop.GetCustomAttribute<RobloxScriptSecurity>() != null)
                {
                    if (!import)
                        Luau.DetailedError($"Luau Error: The current thread cannot read property '{key}'");
                    return null;
                }
                return prop.GetValue(source);
            }
            var field = t.GetField(key, BindingFlags.Instance | BindingFlags.Public);
            if (field != null)
            {
                if (field.GetCustomAttribute<Hidden>() != null)
                {
                    if (!import)
                        Luau.DetailedError($"Luau Error: '{key}' is not a valid member of {source}");
                    return null;
                }
                if (field.GetCustomAttribute<RobloxScriptSecurity>() != null)
                {
                    if (!import)
                        Luau.DetailedError($"Luau Error: The current thread cannot read field '{key}'");
                    return null;
                }
                return field.GetValue(source);
            }
            var nested = t.GetNestedType(key, BindingFlags.Public);
            if (nested != null)
            {
                return nested;
            }

            if(source is Instance)
            {
                return InternalIndexChildren((Instance)source, key, import);
            }
            return null;
        }
    }
}
