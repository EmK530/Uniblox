using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StarterGui : Instance, IInstance, IService
{
    public static object instance;
    public static string publicName = "StarterGui";

    public override void OnInstantiate(Dictionary<string, object> Properties)
    {

    }

    void Awake()
    {
        instance = this;
        Name = publicName;
    }

    [LuauCallable]
    public object[] _SetCoreGuiEnabled(object[] args)
    {
        return new object[0];
    }
}