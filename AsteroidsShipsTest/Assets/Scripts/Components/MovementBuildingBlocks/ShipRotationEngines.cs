using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [AddComponentMenu("Ship Components/Rotation Engines")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipRotationEngines : Engine
    {
        [SerializeField] InputController input;
        new Rigidbody2D rigidbody;
        [SerializeField] private float force = 100;

        private void OnValidate()
        {
            if (input == null)
            {
                input = GetComponent<InputController>();
            }
        }

        private void Awake()
        {
            if(input == null)
            {
                Debug.LogError("There's no input set");
            }
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            OutputForce = input.Rotate;
            rigidbody.AddTorque(-input.Rotate * force);
        }
    } 
}
