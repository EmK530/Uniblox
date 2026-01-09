using System.Collections.Generic;

public class GuiBase2d : GuiBase
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((GuiBase)Derive);
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