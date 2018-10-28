using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wokarol;

public class EnginePowerMonitor : MonoBehaviour
{
    [SerializeField] Engine engine;
    [SerializeField] float output;

    private void Update()
    {
        output = engine.OutputForce;
    }
}
