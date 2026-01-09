using System;
using System.Collections.Generic;
using UnityEngine;

public interface ITask {
    public void Step(float deltaTime);
}

public enum TaskRuntime
{
    ProcessInput,
    fireBindToRenderStepCallbacks, // RunService:BindToRenderStep
    RenderStepped, // RunService.RenderStepped
    RenderSteppedInternal,
    WaitingHybridScriptsJob, // 30 FPS wait()
    PreSimulation,
    Stepped, // FixedUpdate, not quite accurate as it would behave more like FixedHeartbeat
    PostSimulation,
    heartbeatInternal,
    Heartbeat, // RunService.Heartbeat

    Ended, // Task has ended, it will be deleted on the next LateUpdate.
    Unchanged // Task should retain its previous TaskRuntime.
}

public class Task : ITask
{
    public TaskRuntime runtime;
    private Func<float, object, Task, TaskRuntime> function;
    private object context;
    public readonly uint cycleCreated;

    public float continuationTime = -1f;

    public Task(Func<float, object, Task, TaskRuntime> function, TaskRuntime runtime, object context)
    {
        this.function = function;
        this.runtime = runtime;
        this.context = context;
        cycleCreated = TaskScheduler.Cycle;
    }

    public void Step(float deltaTime)
    {
        TaskRuntime newRuntime = function(deltaTime, context, this);
        if (newRuntime != TaskRuntime.Unchanged)
            runtime = newRuntime;
    }

    public void Yield(TaskInstruction inst)
    {
        continuationTime = inst.relatedTime;
    }
}

public class TaskScheduler : MonoBehaviour
{
    public static List<Task> taskList = new List<Task>();

    public static void AddTask(Task task)
    {
        taskList.Add(task);
    }

    public static bool _enabled = false;
    public static void Enable()
    {
        _enabled = true;
    }

    private static void RunTasksOfType(TaskRuntime target, float deltaTime)
    {
        if (!_enabled)
            return;
        foreach (Task task in taskList.ToArray())
        {
            if (task.runtime == target && task.cycleCreated != cycleId && task.continuationTime < Time.realtimeSinceStartup) // Do not execute tasks created same frame
            {
                try
                {
                    task.Step(deltaTime);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Error caught by TaskScheduler: {ex.Message}\n\nUniblox stack trace:\n{ex.StackTrace}\n");
                    task.runtime = TaskRuntime.Ended;
                }
            }
        }
    }

    public float lastHybrid = 0;
    public float lastTrueHybrid = 0;
    public float hybridInterval = 1f / 30f;

    public static uint Cycle
    {
        get { return cycleId; }
    }
    private static uint cycleId = 0;

    void Update()
    {
        cycleId++;

        RunTasksOfType(TaskRuntime.RenderStepped, Time.unscaledDeltaTime);
        RunTasksOfType(TaskRuntime.RenderSteppedInternal, Time.unscaledDeltaTime);
        float diff = Time.realtimeSinceStartup - lastHybrid;
        if (diff > hybridInterval * 2f)
        {
            lastHybrid = Time.realtimeSinceStartup - hybridInterval * 2f;
            diff = Time.realtimeSinceStartup - lastHybrid;
        }
        if (Time.realtimeSinceStartup-lastHybrid >= hybridInterval)
        {
            lastHybrid += hybridInterval;
            RunTasksOfType(TaskRuntime.WaitingHybridScriptsJob, Time.realtimeSinceStartup-lastTrueHybrid);
            lastTrueHybrid = Time.realtimeSinceStartup;
        }
        RunTasksOfType(TaskRuntime.PreSimulation, Time.unscaledDeltaTime);
    }

    void FixedUpdate()
    {
        RunTasksOfType(TaskRuntime.Stepped, Time.fixedDeltaTime);
    }

    void LateUpdate()
    {
        RunTasksOfType(TaskRuntime.PostSimulation, Time.unscaledDeltaTime);
        RunTasksOfType(TaskRuntime.heartbeatInternal, Time.unscaledDeltaTime);
        RunTasksOfType(TaskRuntime.Heartbeat, Time.unscaledDeltaTime);

        taskList.RemoveAll(t => t.runtime == TaskRuntime.Ended);
    }
}
