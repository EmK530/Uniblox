using System.Collections.Generic;

public class Frame : GuiObject, ICreatable, IInstance
{
    public override void OnCreate(object Derive)
    {
        base.OnCreate((GuiObject)Derive);
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