using System;
using System.Collections.Generic;
using System.Diagnostics;
using StateMachineFunc = System.Func<float, bool>;

public static class StateMachine
{
    private static List<StateMachineFunc> tasks = new List<StateMachineFunc>();

    public static void AddTask(StateMachineFunc function)
    {
        tasks.Add(function);
    }

    public static void Step(float deltaTime)
    {
        List<StateMachineFunc> aliveTasks = new List<StateMachineFunc>();
        foreach (var task in tasks)
        {
            try
            {
                if (task(deltaTime))
                    aliveTasks.Add(task);
            } catch(Exception ex) {
                UnityEngine.Debug.LogError($"Error caught by StateMachine: {ex.Message}\n\nUniblox stack trace:\n{ex.StackTrace}");
            }
        }
        tasks.Clear();
        tasks = aliveTasks;
    }
}