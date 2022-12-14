using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Game Event")]
public class GameEvent : ScriptableObject
{
    private List<EventListener> listeners = new List<EventListener>();
    
    public virtual void TriggerEvent() {

        foreach (EventListener listener in listeners) {
            Debug.Log(listener.gameObject.name + " response triggered");
            listener.OnEventTriggered();
        }
    }

    public void AddListener(EventListener listener) {
        listeners.Add(listener);
    }

    public void RemoveListener(EventListener listener) {
        listeners.Remove(listener);
    }
}
