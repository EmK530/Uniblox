using System.Collections.Generic;
using UnityEngine;

public class PVInstance : Instance
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((Instance)Derive);
    }

    public override void OnInstantiate(Dictionary<string, object> Properties)
    {
        base.OnInstantiate(Properties);
    }

    public override void LoadCompleted()
    {
        base.LoadCompleted();
    }
}