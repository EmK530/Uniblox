using System.Collections.Generic;
using UnityEngine.Android;

public static class task
{
    //[LuauCallable] <- Not needed by direct indexing through Dictionary
    public static TaskInstruction wait(object[] args)
    {
        float target = 0f;
        if (args.Length > 0)
        {
            if (!(args[0] is double)) { Luau.ValueError("wait", "number", 1, args[0]); }
            target = UnityEngine.Time.realtimeSinceStartup + (float)args[0];
        }

        return new TaskInstruction()
        {
            action = TaskAction.Wait,
            runtime = TaskRuntime.Heartbeat,
            relatedTime = target,
            deferred = false
        };
    }

    public static object Content = Luau.CreateLuauTable_FromDictionary(new Dictionary<string, object>()
    {
        ["wait"] = new TaskFunction(wait)
    });
}