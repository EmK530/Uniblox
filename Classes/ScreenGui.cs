using System.Collections.Generic;

public class ScreenGui : LayerCollector, ICreatable, IInstance
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((LayerCollector)Derive);
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