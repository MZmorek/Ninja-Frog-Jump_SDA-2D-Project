using UnityEngine;
using FrogNinja.UI;

namespace FrogNinja.States
{
    public class LoseState : BaseState
    {
        public LoseState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }

        public override void EnterState()
        {
            UIManager.Instance.ShowGameOver();
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            
        }

        private void TransitionToMenu()
        {
            myStateMachine.EnterState(new MenuState(myStateMachine));
        }

        private void TransitionToGame()
        {
            myStateMachine.EnterState(new GameState(myStateMachine));
        }
    }
}
