using System.Collections.Generic;
using UnityEngine;

public class Instance : Object
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((Object)Derive);
    }

    public override void OnInstantiate(Dictionary<string, object> Properties)
    {
        Name = (string)Properties["Name"];
        UniqueId = Properties.ContainsKey("UniqueId") ? (Properties["UniqueId"] != null ? (string)Properties["UniqueId"] : Libraries.UniqueId.Create()) : Libraries.UniqueId.Create();
        base.OnInstantiate(Properties);
    }

    public override void LoadCompleted()
    {
        base.LoadCompleted();
    }

    public bool Archivable = true;
    // Capabilities: SecurityCapabilities
    private string _name = null;
    public string Name
    {
        get { return _name; }
        set { _name = value; transform.name = value; }
    }
    private Instance _parent = null;
    public Instance Parent
    {
        get { return _parent; }
        set { _parent = value; if (value != null) { transform.SetParent(value.transform); } }
    }

    [Hidden]
    [PluginSecurity]
    public bool RobloxLocked = false;

    public bool Sandboxed = false; // what the hell is this

    [RobloxSecurity]
    [RobloxScriptSecurity]
    public string UniqueId = null;

    private List<string> Tags = new();
    public void AddTag(object caller, string tag)
    {
        if (Tags.Contains(tag))
            return;
        Tags.Add(tag);
    }
    public void ClearAllChildren(object caller)
    {
        foreach(Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }
    }
    // Clone(): Instance
    // Destroy(): ()
    
    // unfinished

    public Instance()
    {
        
    }
}