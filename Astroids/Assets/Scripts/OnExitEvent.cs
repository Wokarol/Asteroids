using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol.EventTriggers
{
    public class OnExitEvent : MonoBehaviour
    {
        [SerializeField] UnityEvent onExitEvent = new UnityEvent();
        private void OnTriggerExit2D(Collider2D collision)
        {
            onExitEvent.Invoke();
        }
    } 
}
