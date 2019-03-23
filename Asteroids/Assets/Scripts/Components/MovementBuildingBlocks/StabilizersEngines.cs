using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class StabilizersEngines : Engine
    {
        [SerializeField] float linear = 1;
        [SerializeField] float angular = 20;

        new Rigidbody2D rigidbody;

        bool isActive = false;

        private void OnEnable()
        {
            if (rigidbody == null) rigidbody = GetComponent<Rigidbody2D>();
            if (!isActive) {
                Activate();
            }
        }

        private void OnDisable()
        {
            if (isActive) {
                Deactivate();
            }
        }



        private void Activate()
        {
            Debug.Log($"Activated stabilizers for {name}");
            rigidbody.drag += linear;
            rigidbody.angularDrag += angular;
            OutputForce = 1;
            isActive = true;
        }
        private void Deactivate()
        {
            Debug.Log($"Deactivated stabilizers for {name}");
            rigidbody.drag -= linear;
            rigidbody.angularDrag -= angular;
            OutputForce = 0;
            isActive = false;
        }
    }
}
