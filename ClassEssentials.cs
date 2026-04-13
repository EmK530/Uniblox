using System;
using System.Collections.Generic;

// Make a method callable by the Luau emulator, name must be prefixed with an underscore
[AttributeUsage(AttributeTargets.Method)]
public class LuauCallable : Attribute { }

// Makes properties and fields not fetchable from a class instance in the Luau emulator, only the global
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method)]
public class StaticOnly : Attribute { }

// Completely hide properties/fields from the Luau emulator
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class Hidden : Attribute {}

// Hide properties/fields from emulated scripts running lower than CoreScript level
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class RobloxScriptSecurity : Attribute { }

// Make properties/fields non-writable for emulated scripts running lower than CoreScript level
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class RobloxSecurity : Attribute { }

// Hide properties/fields from emulated scripts running lower than Plugin level
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class PluginSecurity : Attribute { }

// Creatable by Clone or Instance.new
public interface ICreatable
{
    void OnCreate(object Derive);
}

// Should be used on all classes deriving off of Instance, to allow child indexing
public interface IInstance
{
    void OnInstantiate(Dictionary<string, object> Properties);
}

// Allow Reflection indexing for properties & functions, already defined on Object and covers all Instance classes.
public interface IIndexable {}

// Add to classes that should be fetchable with GetService
public interface IService {
    public static object instance;
    public static string publicName;
}

public enum TaskAction
{
    Wait,
    Spawn,
    Delay,
    Defer
}

// Used by yielding functions in LuauVM
public class TaskInstruction
{
    public TaskAction action;
    public TaskRuntime runtime;
    public float relatedTime = 0f;
    public bool deferred = false;
}

// Base type for LuauCallable function
public delegate object[] ImmediateFunction(object[] args);

// LuauCallable function that pauses the LuauVM and resumes when this function has returned. Requires a wrapper for proper functionality.
public delegate System.Collections.IEnumerator AsyncFunction(object[] args);

public delegate TaskInstruction TaskFunction(object[] args);

// Wrapper for ImmediateFunction meant for namecalls
public delegate object[] ImmediateFunctionWrapSrc(object source, object[] args);

// Wrapper for AsyncFunction meant for namecalls
public delegate System.Collections.IEnumerator AsyncFunctionWrapSrc(LuauVM caller, object source, object[] args);

// General wrapper for AsyncFunction
public delegate System.Collections.IEnumerator AsyncFunctionWrap(LuauVM caller, object[] args);