using UnityEngine;

public static class EventManager
{
    public static event System.Action EnterGameplay;
    public static event System.Action EnterMenu;
    public static event System.Action<Vector2> PlayerPositionUpdate;
    public static event System.Action<int> CurrentScoreUpdated;
    public static event System.Action PlayerFallenOff;

    public static void EnterGameplayButton()
    {
        if (EnterGameplay != null)
        {
            EnterGameplay.Invoke();
        }
    }

    public static void OnUpdatePlayerPosition(Vector2 position)
    {
        if (PlayerPositionUpdate != null)
        {
            PlayerPositionUpdate(position);
        }
    }
    public static void EnterMenuButton()
    {
        if (EnterMenu != null)
        {
            EnterMenu.Invoke();
        }
    }


    public static void OnUpdateScore(int score)
    {
        if (CurrentScoreUpdated != null)
        {
            CurrentScoreUpdated(score);
        }
    }
    public static void OnPlayerFallenOff()
    {
        if (PlayerFallenOff != null)
        {
            PlayerFallenOff();
        }
    }
}
