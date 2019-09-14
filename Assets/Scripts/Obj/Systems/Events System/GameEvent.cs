using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventsListener> listeners = new List<GameEventsListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventsListener evnt)
    {
        if(!listeners.Contains(evnt)) listeners.Add(evnt);
    }

    public void UnregisterListener(GameEventsListener evnt)
    {
        if (listeners.Contains(evnt)) listeners.Remove(evnt);
    }
}
