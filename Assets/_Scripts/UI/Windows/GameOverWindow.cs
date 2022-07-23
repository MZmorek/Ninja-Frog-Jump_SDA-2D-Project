using UnityEngine;
using UnityEngine.SceneManagement;

namespace FrogNinja.UI
{
    public class GameOverWindow : BaseWindow
    {
        public void Button_RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Button_MainMenu()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
