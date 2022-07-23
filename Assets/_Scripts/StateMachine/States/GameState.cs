using UnityEngine;
using FrogNinja.UI;

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
            UIManager.Instance.ShowHUD();
        }

        public override void ExitState()
        {
            Debug.Log("Exit GameState");
        }

        public override void UpdateState()
        {

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
