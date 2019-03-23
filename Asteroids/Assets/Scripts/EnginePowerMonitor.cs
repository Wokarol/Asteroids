using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wokarol;

public class EnginePowerMonitor : MonoBehaviour
{
    [SerializeField] Engine engine = null;
    [SerializeField] float output = 0;

    private void Update()
    {
        output = engine.OutputForce;
    }
}
