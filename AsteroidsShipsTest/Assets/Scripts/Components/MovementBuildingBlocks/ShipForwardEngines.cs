using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [AddComponentMenu("Ship Components/Forward Engines")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipForwardEngines : Engine
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
            if (input == null)
            {
                Debug.LogError("There's no input set");
            }
            rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            OutputForce = input.Thrust;
            rigidbody.AddRelativeForce(Vector2.up * (input.Thrust * force));
        }
    } 
}
