using System.Collections.Generic;

public class LayerCollector : GuiBase2d
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((GuiBase2d)Derive);
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