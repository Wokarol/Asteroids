using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [RequireComponent(typeof(ActorHealth))]
    public class Hittable : MonoBehaviour
    {
        [SerializeField] float velocityThreshold = 7f;
        [SerializeField] int hitDamage = 1;
        [Space]
        [SerializeField] float unhittableFrame = 1f;

        ActorHealth actorHealth;

        float unhittableCountDown = -1;
        bool unhittable = false;

        private void Awake()
        {
            actorHealth = GetComponent<ActorHealth>();
        }

        private void Update()
        {
            if (unhittableCountDown > 0) {
                unhittableCountDown -= Time.deltaTime;
            } else if (unhittableCountDown <= 0 && unhittable) {
                unhittable = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!unhittable && collision.relativeVelocity.sqrMagnitude > (velocityThreshold * velocityThreshold)) {
                unhittable = true;
                unhittableCountDown = unhittableFrame;

                Debug.Log($"{name} -> has taken {hitDamage} damage because of collision with -> {collision.gameObject.name}");
                actorHealth.Hit(hitDamage);
            }
        }
    }
}
