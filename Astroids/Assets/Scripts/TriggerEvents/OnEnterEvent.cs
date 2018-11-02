using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol.EventTriggers
{
    public class OnEnterEvent : EventTrigger
    {
        [SerializeField] UnityEvent onEnterEvent = new UnityEvent();
        private void OnTriggerEnter2D(Collider2D collision)
        {
            TriggerEvent(() => onEnterEvent.Invoke());
        }
    } 
}
