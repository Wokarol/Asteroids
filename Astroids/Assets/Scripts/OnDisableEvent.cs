using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDisableEvent : MonoBehaviour
{
    [SerializeField] UnityEvent unityEvent;
    private void OnDisable()
    {
        unityEvent.Invoke();
    }
}
