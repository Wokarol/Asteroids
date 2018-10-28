using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wokarol.LocalEvents;

public class TargetLocalEventTrigger : MonoBehaviour
{
    [SerializeField] EventName eventToCall;

    LocalEventHandler eventHandler;
    public void SetTarget(GameObject ob)
    {
        eventHandler = ob.GetComponent<LocalEventHandler>();
    }

    public void CallEvent()
    {
        Debug.Log($"Calling {eventToCall.name}");
        eventHandler.CallEvent(eventToCall);
    }
}
