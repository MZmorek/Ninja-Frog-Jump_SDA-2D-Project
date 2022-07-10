using FrogNinja.States;
using UnityEngine;

public class MenuState : BaseState
{
    public MenuState(StateMachine stateMachine)
    {
        Initialize(stateMachine);
    }
    public override void EnterState()
    {
        Debug.Log("MenuState entered");
    }

    public override void ExitState()
    {
        Debug.Log("Exit MenuState");
    }

    public override void UpdateState()
    {
        Debug.Log("MenuState updated");
    }
}

