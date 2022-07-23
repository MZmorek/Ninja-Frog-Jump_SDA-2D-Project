using UnityEngine;
using FrogNinja.UI;
using System;

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
            EventManager.PlayerFallenOff += EventManager_PlayerFallenOff;
            UIManager.Instance.ShowHUD();
        }

        public override void ExitState()
        {
            Debug.Log("Exit GameState");
            EventManager.PlayerFallenOff -= EventManager_PlayerFallenOff;
        }

        private void EventManager_PlayerFallenOff()
        {
            GoToGameOver();
        }

        public override void UpdateState()
        {

        }

        private void GoToMenu()
        {
            myStateMachine.EnterState(new MenuState(myStateMachine));
        }

        private void GoToGameOver()
        {
            myStateMachine.EnterState(new LoseState(myStateMachine));
        }
    }
}
