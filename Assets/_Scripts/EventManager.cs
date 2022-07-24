using UnityEngine;

public static class EventManager
{
    #region Button Events
    public static event System.Action EnterGameplay;
    public static event System.Action EnterMenu;

    public static void EnterMenuButton()
    {
        if (EnterMenu != null)
        {
            EnterMenu.Invoke();
        }
    }
    public static void EnterGameplayButton()
    {
        if (EnterGameplay != null)
        {
            EnterGameplay.Invoke();
        }
    }
    #endregion

    #region Player Events
    public static event System.Action<Vector2> PlayerPositionUpdate;
    public static event System.Action PlayerDied;
    public static void OnUpdatePlayerPosition(Vector2 position)
    {
        if (PlayerPositionUpdate != null)
        {
            PlayerPositionUpdate(position);
        }
    }
    public static void OnPlayerDied()
    {
        if (PlayerDied != null)
        {
            PlayerDied();
        }
    }
    #endregion

    #region Score Events
    public static event System.Action<int> CurrentScoreUpdated;
    public static void OnUpdateScore(int score)
    {
        if (CurrentScoreUpdated != null)
        {
            CurrentScoreUpdated(score);
        }
    }

    #endregion

    #region Enemy Events
    public static event System.Action EnemyHitPlayer;
    public static event System.Action EnemyDied;

    public static void OnEnemyHitPlayer()
    {
        if (EnemyHitPlayer != null)
        {
            EnemyHitPlayer(); 
        }
    }

    public static void OnEnemyDied()
    {
        if (EnemyDied != null)
        {
            EnemyDied();
        }
    }

    #endregion




}
