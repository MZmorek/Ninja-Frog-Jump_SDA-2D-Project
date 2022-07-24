using FrogNinja.Player;
using FrogNinja.UI;
using System;
using UnityEngine;

namespace FrogNinja.States
{
    public class GameState : BaseState
    {

        PlayerController playerController;

        private bool gamePaused = false;
        public GameState(StateMachine stateMachine)
        {
            Initialize(stateMachine);
        }

        public override void EnterState()
        {
            playerController = GameObject.FindObjectOfType<PlayerController>();
            playerController.SwitchState(true);

            AudioSystem.SwitchMusic_Global(true);

            EventManager.PlayerDied += EventManager_PlayerDied;
            EventManager.EnemyHitPlayer += EventManager_EnemyHitPlayer;
            EventManager.EnterPause += EventManager_EnterPause;
            UIManager.Instance.ShowHUD();
        }

        private void EventManager_EnterPause()
        {
            PauseGame();
        }

        private void PauseGame()
        {
            gamePaused = !gamePaused;

            EventManager.OnPause(gamePaused);

            if (gamePaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

            playerController.SwitchState(!gamePaused, false);

            AudioSystem.PlayPauseSFX_Global(gamePaused);
            AudioSystem.SwitchMusic_Global(!gamePaused);

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

            EventManager.PlayerDied -= EventManager_PlayerDied;
            EventManager.EnemyHitPlayer -= EventManager_EnemyHitPlayer;
            EventManager.EnterPause -= EventManager_EnterPause;

            AudioSystem.SwitchMusic_Global(false);
        }

        private void EventManager_PlayerDied()
        {
            GoToGameOver();
        }

        public override void UpdateState()
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                PauseGame();
            }
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
