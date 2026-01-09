using System.Collections.Generic;
using UnityEngine;

// This class exists just for proper ClassName support and really is meant to be just empty.
// https://create.roblox.com/docs/reference/engine/classes/Folder

public class Folder : Instance, ICreatable, IInstance
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((Instance)Derive);
    }

    // Called when instantiated by GameLoader
    public override void OnInstantiate(Dictionary<string, object> Properties)
    {
        base.OnInstantiate(Properties);
    }

    public override void LoadCompleted()
    {
        base.LoadCompleted();
    }
}