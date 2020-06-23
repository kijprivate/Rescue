using System;

public class EventManager
{
    private static Action EventGameStarted;
    public static void RaiseEventGameStarted()
    {
        EventGameStarted?.Invoke();
    }
    public static void SubscribeToEventGameStarted(Action method)
    {
        EventGameStarted += method;
    }
    public static void UnsubscribeFromEventGameStarted(Action method)
    {
        EventGameStarted -= method;
    }

    private static Action EventGameOver;
    public static void RaiseEventGameOver()
    {
        EventGameOver?.Invoke();
    }
    public static void SubscribeToEventGameOver(Action method)
    {
        EventGameOver += method;
    }
    public static void UnsubscribeFromEventGameOver(Action method)
    {
        EventGameOver -= method;
    }

    private static Action EventCharacterDestroyed;
    public static void RaiseEventCharacterDestroyed()
    {
        EventCharacterDestroyed?.Invoke();
    }
    public static void SubscribeToEventCharacterDestroyed(Action method)
    {
        EventCharacterDestroyed += method;
    }
    public static void UnsubscribeFromEventCharacterDestroyed(Action method)
    {
        EventCharacterDestroyed -= method;
    }
}
