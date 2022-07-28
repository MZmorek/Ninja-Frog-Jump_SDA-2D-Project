using UnityEngine;

namespace FrogNinja.UI
{
    public class MainMenuWindow : BaseWindow
    {
        public void Button_PlayGame()
        {
            EventManager.EnterGameplayButton();
        }

        public void Button_OpenSettings()
        {
            EventManager.EnterSettingsButton();
        }

        public void Button_ExitGame()
        {
            Application.Quit();
        }
    }
}