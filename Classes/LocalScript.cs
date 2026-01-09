using System.Collections.Generic;
using UnityEngine;

// This class exists just for proper ClassName support and really is meant to be just empty.
// https://create.roblox.com/docs/reference/engine/classes/LocalScript

public class LocalScript : Script, IInstance, ICreatable
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((Script)Derive);
        if (GetType() == typeof(LocalScript))
            LoadCompleted();
    }

    // Called when instantiated by GameLoader
    public override void OnInstantiate(Dictionary<string, object> Properties)
    {
        base.OnInstantiate(Properties);
        if (GetType() == typeof(LocalScript))
            LoadCompleted();
    }

    public override void LoadCompleted()
    {
        base.LoadCompleted();
    }
}