using UnityEngine;
using UnityEngine.Events;

namespace Wokarol.EventTriggers
{
    public abstract class EventTrigger : MonoBehaviour
    {
        [SerializeField] bool OneTimeTrigger = false;
        bool used;
        protected void TriggerEvent(System.Action onEvent)
        {
            if ((OneTimeTrigger && !used) || !OneTimeTrigger) {
                onEvent.Invoke();
                used = true;
            }
        }
    }
}