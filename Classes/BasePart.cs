using System.Collections.Generic;
using UnityEngine;

public class BasePart : PVInstance
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((PVInstance)Derive);
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