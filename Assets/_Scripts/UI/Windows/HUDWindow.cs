using UnityEngine;

namespace FrogNinja.UI
{
    public class HUDWindow : BaseWindow
    {
        [SerializeField] private TMPro.TMP_Text scoreCounter;

        public override void ShowWindow()
        {
            scoreCounter.text = "0";

            base.ShowWindow();
        }
        public void Button_PauseGame()
        {

        }
    }
}
