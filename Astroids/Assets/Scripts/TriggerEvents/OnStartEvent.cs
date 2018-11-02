using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol.EventTriggers
{
    public class OnStartEvent : EventTrigger
    {
        [SerializeField] UnityEvent onStartEvent = new UnityEvent();
        private void Start()
        {
            TriggerEvent(() => onStartEvent.Invoke());
        }
    } 
}
