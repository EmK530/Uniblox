using UnityEngine;

public class StateMachineStepper : MonoBehaviour
{
    void Update()
    {
        StateMachine.Step(Time.unscaledDeltaTime);
    }
}
