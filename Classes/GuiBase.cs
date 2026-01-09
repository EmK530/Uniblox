using System.Collections.Generic;

// This class exists just for proper ClassName support and really is meant to be just empty.
// https://create.roblox.com/docs/reference/engine/classes/GuiBase

public class GuiBase : Instance
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