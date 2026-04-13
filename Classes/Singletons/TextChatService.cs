using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextChatService : Instance, IInstance, IService
{
    public static object instance;
    public static string publicName = "TextChatService";

    public override void OnInstantiate(Dictionary<string, object> Properties)
    {
        
    }

    void Awake()
    {
        instance = this;
        Name = publicName;
    }
}