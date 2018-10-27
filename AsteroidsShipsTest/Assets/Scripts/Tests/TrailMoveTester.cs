using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrailMoveTester : MonoBehaviour
{
    [SerializeField] ScreenTeleportEvent screenTeleportEvent = null;
    [SerializeField] Transform target = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6)) {
            screenTeleportEvent.Invoke(Vector3.left * 5);
            target.position += Vector3.left * 5;
        }
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F7)) {
            screenTeleportEvent.Invoke(Vector3.left * 5);
            target.position += Vector3.left * 5;
        }
    }

    [System.Serializable]
    class ScreenTeleportEvent : UnityEvent<Vector3> { }
}
