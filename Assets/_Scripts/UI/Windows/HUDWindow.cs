using System;
using UnityEngine;

namespace FrogNinja.UI
{
    public class HUDWindow : BaseWindow
    {
        [SerializeField] private TMPro.TMP_Text scoreCounter;
        [SerializeField] private GameObject pauseOverlay;

        public override void ShowWindow()
        {
            scoreCounter.text = "0";
            pauseOverlay.SetActive(false);

            EventManager.CurrentScoreUpdated += EventManager_CurrentScoreUpdated;
            EventManager.Pause += EventManager_Pause;
            base.ShowWindow();
        }

        public override void HideWindow()
        {
            pauseOverlay.SetActive(false);
            EventManager.Pause -= EventManager_Pause;

            EventManager.CurrentScoreUpdated -= EventManager_CurrentScoreUpdated;
            base.HideWindow();
        }
        private void EventManager_Pause(bool obj)
        {
            pauseOverlay.SetActive(obj);
        }

        private void EventManager_CurrentScoreUpdated(int obj)
        {
            scoreCounter.text = obj.ToString();
        }

        public void Button_PauseGame()
        {
            EventManager.EnterPauseButton();
        }
    }
}
