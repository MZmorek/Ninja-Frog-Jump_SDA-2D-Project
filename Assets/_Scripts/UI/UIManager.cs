using UnityEngine;

namespace FrogNinja.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        [SerializeField] MainMenuWindow mainMenu;
        [SerializeField] HUDWindow hud;

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

        public void ShowHUD()
        {
            HideAndSwitchWindow(hud);
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

        public void ShowFail()
        {

        }
    }
}