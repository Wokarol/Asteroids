using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Wokarol
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class VelocityLimiter : MonoBehaviour
    {
        new Rigidbody2D rigidbody;
        [SerializeField] float maxVelocity = 20;
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var velocity = rigidbody.velocity;
            if(velocity.magnitude > maxVelocity) {
                rigidbody.velocity = velocity.normalized * maxVelocity;
            }
        }
    } 
}
