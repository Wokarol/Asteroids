using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Wokarol
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class VelocityMonitor : MonoBehaviour
    {
        new Rigidbody2D rigidbody;
        [SerializeField] float velocity;
        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            velocity = rigidbody.velocity.magnitude;
        }
    } 
}
