using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEvent = new UnityEvent();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEvent.Invoke();
    }
}
