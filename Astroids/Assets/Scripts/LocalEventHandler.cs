using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol.LocalEvents
{
    public class LocalEventHandler : MonoBehaviour
    {
        [SerializeField] List<LocalEvent> localEvents;

        public void CallEvent(EventName eventName)
        {
            foreach (var e in localEvents) {
                if(e.Name == eventName) {
                    Debug.Log($"Called {e.Name.name}");
                    e.Event.Invoke();
                }
            }
        }

        [System.Serializable]
        private class LocalEvent
        {
            public EventName Name;
            public UnityEvent Event;
        }
    } 
}
