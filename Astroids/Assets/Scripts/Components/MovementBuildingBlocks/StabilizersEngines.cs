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
        [SerializeField] bool activeOnStart = true;

        new Rigidbody2D rigidbody;

        bool isActive = false;

        private void OnEnable()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            if(!isActive && activeOnStart) {
                SetActive(true);
            }
        }

        public void SetActive(bool state)
        {
            if (state) Activate();
            else Deactivate();
        }

        private void Activate()
        {
            rigidbody.drag += linear;
            rigidbody.angularDrag += angular;
            OutputForce = 1;
        }
        private void Deactivate()
        {
            rigidbody.drag -= linear;
            rigidbody.angularDrag -= angular;
            OutputForce = 0;
        }
    } 
}
