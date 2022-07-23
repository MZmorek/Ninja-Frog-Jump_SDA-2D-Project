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
            EventManager.EnterGameplay += EventManager_EnterGameplay;
            EventManager.EnterMenu += EventManager_EnterMenu;

        }
        private void EventManager_EnterGameplay()
        {
            GoToGame();
        }

        private void EventManager_EnterMenu()
        {
            GoToMenu();
        }


        public override void ExitState()
        {
            EventManager.EnterGameplay -= EventManager_EnterGameplay;
            EventManager.EnterMenu -= EventManager_EnterMenu;
        }

        public override void UpdateState()
        {
            
        }

        private void GoToMenu()
        {
            myStateMachine.EnterState(new MenuState(myStateMachine));
        }

        private void GoToGame()
        {
            myStateMachine.EnterState(new GameState(myStateMachine));
        }
    }
}
