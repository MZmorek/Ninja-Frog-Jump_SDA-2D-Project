using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private const string HIGH_SCORE_KEY = "high_score";
    [SerializeField] int positionDifferenceMultiplier = 100;
    [SerializeField] AudioClip highScoreSFX;
    private int currentScore;
    private int highScore;
    public int CurrentScore { get { return currentScore; } }
    public int HighScore { get { return highScore; } }
    private float maxPositionY;
    private bool firstUpdate = true;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        EventManager.EnterGameplay += EventManager_EnterGameplay;
        EventManager.PlayerPositionUpdate += EventManager_PlayerPositionUpdate;
        EventManager.PlayerDied += EventManager_PlayerDied;
        EventManager.EnemyDied += EventManager_EnemyDied;
    }

    private void OnDestroy()
    {
        EventManager.PlayerPositionUpdate -= EventManager_PlayerPositionUpdate;
        EventManager.EnterGameplay -= EventManager_EnterGameplay;
        EventManager.PlayerDied -= EventManager_PlayerDied;
        EventManager.EnemyDied -= EventManager_EnemyDied;
    }
    private void EventManager_EnterGameplay()
    {
        firstUpdate = true;
        currentScore = 0;
    }

    private void EventManager_EnemyDied()
    {
        currentScore += 150;
        EventManager.OnUpdateScore(currentScore);
    }

    private void EventManager_PlayerPositionUpdate(Vector2 obj)
    {
        if (firstUpdate == true)
        {
            maxPositionY = obj.y;
            currentScore = 0;
            firstUpdate = false;
            return;
        }

        if (obj.y > maxPositionY)
        {
            float difference = obj.y - maxPositionY;
            currentScore += (int)(difference * positionDifferenceMultiplier);

            maxPositionY = obj.y;

            EventManager.OnUpdateScore(currentScore);
        }
    }

    private void EventManager_PlayerDied()
    {
        SaveHighScore();
    }

    private void SaveHighScore()
    {
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, currentScore);
            highScore = currentScore;

            Invoke("PlayJingle", 1.5f);
        }
    }
    private void PlayJingle()
    {
        AudioSystem.PlaySFX_Global(highScoreSFX);
    }
}

