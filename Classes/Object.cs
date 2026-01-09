using System;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour, IIndexable
{
    public virtual void OnCreate(object Derive)
    {
        
    }

    public virtual void OnInstantiate(Dictionary<string, object> Properties)
    {

    }

    public virtual void LoadCompleted()
    {

    }

    // Properties
    public virtual string ClassName => GetType().Name;

    // Methods
    // Cannot implement GetPropertyChangedSignal without the emulator being in place
    public bool IsA(object caller, string className)
    {
        // Caller will have a proper type later and is related to the emulator.
        // The standard should be to pass something emulator related as the first argument
        // so that native functions like task.wait and others can properly yield a script.

        if (className == ClassName)
            return true;
        Type t = GetType();
        while(t != null)
        {
            if (t.Name == className)
                return true;
            t = t.BaseType;
        }
        return false;
    }

    // Events
    // Cannot implement Changed without the emulator being in place
}