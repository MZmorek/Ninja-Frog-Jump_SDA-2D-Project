using UnityEngine;

namespace FrogNinja.States
{
    public class GameState : BaseState
    {
        public GameState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }

        public override void EnterState()
        {
            Debug.Log("Enter GameState");
        }

        public override void ExitState()
        {
            Debug.Log("Exit GameState");
        }

        public override void UpdateState()
        {
            Debug.Log("Update GameState");
        }

        private void TransitionToMenu()
        {
            myStateMachine.EnterState(new MenuState(myStateMachine));
        }

        private void TransitionToLose()
        {
            myStateMachine.EnterState(new LoseState(myStateMachine));
        }
    }
}
