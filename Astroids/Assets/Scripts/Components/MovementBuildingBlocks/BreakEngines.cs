using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [AddComponentMenu("Ship Components/Break Engines")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class BreakEngines : Engine
    {
        [SerializeField] InputController input;
        new Rigidbody2D rigidbody;
        [SerializeField] private float strenght = 3f;

        private void OnValidate()
        {
            if (input == null) {
                input = GetComponent<InputController>();
            }
        }

        private void Awake()
        {
            if (input == null) {
                Debug.LogError("There's no input set");
            }
            rigidbody = GetComponent<Rigidbody2D>();
        }

        bool wasPressed = false;
        // Update is called once per frame
        void FixedUpdate()
        {
            if(input.Breaking > 0.6f && !wasPressed) {
                OutputForce = 1;
                wasPressed = true;
                rigidbody.drag += strenght;
            }
            if (input.Breaking < 0.4f && wasPressed) {
                OutputForce = 0;
                wasPressed = false;
                rigidbody.drag -= strenght;
            }
        }

    }
}
