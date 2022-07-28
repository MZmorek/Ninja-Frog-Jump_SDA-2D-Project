using UnityEngine;

namespace FrogNinja.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] MainMenuWindow mainMenu;
        [SerializeField] SettingsWindow settings;
        [SerializeField] HUDWindow hud;
        [SerializeField] GameOverWindow gameOver;
        [SerializeField] PauseWindow pause;

        BaseWindow currentlyOpenWindow;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            Instance = this;
        }

        public void ShowMainMenu()
        {
            HideAndSwitchWindow(mainMenu);
        }
        public void ShowSettings()
        {
            HideAndSwitchWindow(settings);
        }

        public void ShowHUD()
        {
            HideAndSwitchWindow(hud);
        }
        public void ShowGameOver()
        {
            HideAndSwitchWindow(gameOver);
        }

        public void ShowPause()
        {
            HideAndSwitchWindow(pause);
        }

        private void HideAndSwitchWindow(BaseWindow windowToSwitchTo)
        {
            if (currentlyOpenWindow != null)
            {
                currentlyOpenWindow.HideWindow();
            }
            currentlyOpenWindow = windowToSwitchTo;
            currentlyOpenWindow.ShowWindow();
        }
    }
}