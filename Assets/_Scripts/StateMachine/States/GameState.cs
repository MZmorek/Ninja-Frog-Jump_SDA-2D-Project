using FrogNinja.UI;
using System;
using UnityEngine;

namespace FrogNinja.States
{
    public class GameState : BaseState
    {

        PlayerController playerController;
        public GameState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }

        public override void EnterState()
        {
            Debug.Log("Enter GameState");

            playerController = GameObject.FindObjectOfType<PlayerController>();
            playerController.SwitchState(true);

            EventManager.PlayerDied += EventManager_PlayerDied;
            EventManager.EnemyHitPlayer += EventManager_EnemyHitPlayer;
            UIManager.Instance.ShowHUD();
        }

        private void EventManager_EnemyHitPlayer()
        {
            EventManager.OnPlayerDied();
        }

        public override void ExitState()
        {
            if (playerController != null)
            {
                playerController.SwitchState(false);
            }

            Debug.Log("Exit GameState");
            EventManager.PlayerDied -= EventManager_PlayerDied;
            EventManager.EnemyHitPlayer -= EventManager_EnemyHitPlayer;
        }

        private void EventManager_PlayerDied()
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
