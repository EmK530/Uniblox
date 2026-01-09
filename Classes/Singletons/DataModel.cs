using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class DataModel : Instance, IInstance
{
    public static DataModel instance;


    public override void OnInstantiate(Dictionary<string, object> Properties)
    {
        // Static object not created by GameLoader
    }

    void Awake()
    {
        instance = this;
        Name = gameObject.name;
    }

    private static IEnumerable<Type> manyTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());

    [LuauCallable]
    public object[] _GetService(object[] args)
    {
        string serviceName = args[0].ToString();
        Type serviceType = manyTypes.FirstOrDefault(t => typeof(IService).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract && t.Name == serviceName);
        if (serviceType == null)
            Luau.DetailedError($"Luau Error: '{serviceName}' is not a valid Service name");

        var instanceProp = serviceType.GetField(
            "instance",
            BindingFlags.Static | BindingFlags.Public
        );
        // Service has not been created yet, do so manually.
        object instance = instanceProp.GetValue(null);
        if (instance == null)
        {
            var publicNameProp = serviceType.GetField(
                "publicName",
                BindingFlags.Static | BindingFlags.Public
            );
            GameObject go = new GameObject((string)publicNameProp.GetValue(null));
            go.transform.SetParent(transform);
            instance = (Instance)go.AddComponent(serviceType);
            instanceProp.SetValue(null, instance);
        }
        return new object[1] { instance };
    }
}