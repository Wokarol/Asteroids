using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [AddComponentMenu("Ship Components/Booster Engines")]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ShipBoostEngines : Engine
    {
        [SerializeField] InputController input;
        new Rigidbody2D rigidbody;
        [SerializeField] private float force = 100;
        [SerializeField] private float cooldownTime = 1;
        [SerializeField] private float boostTime = 0.1f;

        private float cooldownCounter = 0;
        private float boostCounter = 0;

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

        void FixedUpdate()
        {
            if (input.Boost && cooldownCounter <= 0)
            {
                cooldownCounter = cooldownTime;
                boostCounter = boostTime;
            }

            if (boostCounter > 0)
            {
                OutputForce = 1;
                rigidbody.AddRelativeForce(Vector2.up * force);
            } else {
                OutputForce = 0;
            }


            cooldownCounter -= Time.deltaTime;
            boostCounter -= Time.deltaTime;
        }
    } 
}
