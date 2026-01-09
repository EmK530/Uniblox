using System.Collections.Generic;
using UnityEngine;

public class BaseScript : LuaSourceContainer
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((LuaSourceContainer)Derive);
    }

    // Called when instantiated by GameLoader
    public override void OnInstantiate(Dictionary<string, object> Properties)
    {
        base.OnInstantiate(Properties);
        if (Properties.ContainsKey("Disabled")) { Disabled = (bool)Properties["Disabled"]; }
    }

    private bool HasLoaded = false;
    public override void LoadCompleted()
    {
        base.LoadCompleted();
        HasLoaded = true;
        if (_active && GetType() == typeof(LocalScript)) // temporary
            GameLoader.GameLoadCompleted.AddListener(_awake);
    }

    private LuauVM VM = null;

    private void _awake()
    {
        if(CompiledSource.Length == 0)
        {
            Debug.LogWarning($"Cannot execute script '{this.Name}' because it has no CompiledSource.");
            return;
        }
        Debug.Log($"Creating new LuauVM for script '{this.Name}'");
        VM = new LuauVM(CompiledSource, this.Name, this);
    }

    [Hidden]
    public virtual string Source { get; set; } // BaseScript needs to see this to manage the VM, override this in Script.

    [Hidden]
    public byte[] CompiledSource = new byte[0]; // Internal variable that contains bytecode

    private bool _active = true;
    private bool Active
    {
        get { return _active; }
        set {
            _active = value;
            if (VM == null && value && HasLoaded)
                _awake();
        }
    }
    public bool Disabled
    {
        get { return !Active; }
        set { Active = !value; }
    }
    public bool Enabled
    {
        get { return Active; }
        set { Active = value; }
    }
    // Cannot add RunContext until Enum is added
}