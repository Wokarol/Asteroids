using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [RequireComponent(typeof(ActorHealth))]
    public class Test_ActorHealth : MonoBehaviour
    {
        ActorHealth actorHealth;
        private void Awake()
        {
            actorHealth = GetComponent<ActorHealth>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F5)) {
                actorHealth.Hit(1);
            }
        }
    } 
}
