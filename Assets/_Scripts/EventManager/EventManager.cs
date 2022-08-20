
using UnityEngine;

public static class EventManager
{
    public static event System.Action EnterGameplay;

    public static void EnterGameplayButton()
    {
        if (EnterGameplay != null)
        {
            EnterGameplay.Invoke();
        }
    }
}
