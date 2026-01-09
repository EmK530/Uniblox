using System.Collections.Generic;

// Pcalls are yet to be supported
public class PcallStub {};

public static class LuauGlobals
{
    public static Dictionary<string, object> defaultEnvironment;

    // To be called by GameLoader, before creating objects that trigger script compilation.
    private static bool initialized = false;
    public static void Initialize()
    {
        if (initialized)
            return;

        defaultEnvironment = new()
        {
            ["game"] = DataModel.instance,
            ["task"] = task.Content,
            ["pcall"] = new PcallStub(),
            ["Enum"] = typeof(Enum)
        };
    }
}
