using TMPro;
using UnityEngine;

namespace FrogNinja.UI
{
    public class GameOverWindow : BaseWindow
    {
        [SerializeField] GameObject textObjectHolder;
        [SerializeField] TMP_Text currentScore;
        [SerializeField] TMP_Text highScore;

        public override void ShowWindow()
        {
            base.ShowWindow();
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            bool hasScoreManager = scoreManager != null;

            if (!hasScoreManager)
            {
                return;
            }

            currentScore.text = $"Current Score: {scoreManager.CurrentScore}";
            highScore.text = $"High Score: {scoreManager.HighScore}";

        }
        public void Button_RestartGame()
        {
            EventManager.EnterGameplayButton();
        }

        public void Button_MainMenu()
        {
            EventManager.EnterMenuButton();
        }
    }
}
