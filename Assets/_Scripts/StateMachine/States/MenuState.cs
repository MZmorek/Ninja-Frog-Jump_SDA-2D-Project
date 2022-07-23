using FrogNinja.UI;
using UnityEngine;

namespace FrogNinja.States
{
    public class MenuState : BaseState
    {
        public MenuState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }
        public override void EnterState()
        {
            Debug.Log("MenuState entered");
            EventManager.EnterGameplay += EventManager_EnterGameplay;
            UIManager.Instance.ShowMainMenu();
        }

        private void EventManager_EnterGameplay()
        {
            TransitionToGame();
        }

        public override void ExitState()
        {
            Debug.Log("Exit MenuState");

            EventManager.EnterGameplay -= EventManager_EnterGameplay;
        }

        public override void UpdateState()
        {

        }
        private void TransitionToGame()
        {
            myStateMachine.EnterState(new GameState(myStateMachine));
        }
    }
}

