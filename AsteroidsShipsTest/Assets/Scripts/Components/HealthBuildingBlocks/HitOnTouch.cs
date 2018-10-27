using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class HitOnTouch : MonoBehaviour
    {
        [SerializeField] int hitForce = 1;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Debug.Log($"<b>{collision.otherCollider.name} hitted something, something has name: {collision.gameObject.name}</b>");

            var actorHealth = collision.gameObject.GetComponentInParent<ActorHealth>();
            if (actorHealth != null) {
                actorHealth.Hit(hitForce);
            }
        }
    } 
}
