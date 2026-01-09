using System.Collections.Generic;
using UnityEngine;

public class Script : BaseScript, IInstance, ICreatable
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((BaseScript)Derive);
        if (GetType() == typeof(Script))
            LoadCompleted();
    }

    // Called when instantiated by GameLoader
    public override void OnInstantiate(Dictionary<string, object> Properties)
    {
        base.OnInstantiate(Properties);
        if(Properties.ContainsKey("Source"))
        {
            object val = Properties["Source"];
            if(val is byte[] b)
            {
                this.CompiledSource = b;
            } else
            {
                Debug.LogWarning($"Script name '{this.Name}' was instantiated with Source Code and not Bytecode. This is not supported yet.");
            }
        }
        if (GetType() == typeof(Script))
            LoadCompleted();
    }

    public override void LoadCompleted()
    {
        base.LoadCompleted();
    }

    [PluginSecurity]
    public override string Source
    {
        get { return ""; } // todo
        set { }
    }
}