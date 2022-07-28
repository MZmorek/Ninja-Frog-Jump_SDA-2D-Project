using FrogNinja.UI;
using System;
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
            AudioSystem.SwitchMusic_Global(true);
            EventManager.EnterGameplay += EventManager_EnterGameplay;
            EventManager.EnterSettings += EventManager_EnterSettings;
            UIManager.Instance.ShowMainMenu();
        }

        private void EventManager_EnterSettings()
        {
            GoToSettings();
        }

        private void EventManager_EnterGameplay()
        {
            GoToGame();
        }

        public override void ExitState()
        {
            Debug.Log("Exit MenuState");

            EventManager.EnterGameplay -= EventManager_EnterGameplay;
            EventManager.EnterSettings -= EventManager_EnterSettings;
        }

        public override void UpdateState()
        {

        }
        private void GoToGame()
        {
            myStateMachine.EnterState(new GameState(myStateMachine));
        }
        private void GoToSettings()
        {
            myStateMachine.EnterState(new SettingsState(myStateMachine));
        }
    }
}

