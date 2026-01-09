using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunService : Instance, IInstance, IService
{
    public static object instance;
    public static string publicName = "Run Service";

    public override void OnInstantiate(Dictionary<string, object> Properties)
    {
        
    }

    void Awake()
    {
        instance = this;
        Name = publicName;
    }

    [LuauCallable]
    public object[] _IsStudio(object[] args)
    {
        return new object[1] { Application.isEditor };
    }
}