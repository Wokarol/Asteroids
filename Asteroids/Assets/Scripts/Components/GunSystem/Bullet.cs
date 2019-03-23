using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wokarol.PoolSystem;

namespace Wokarol.WeaponSystem
{
    public class Bullet : PoolObject
    {
        [SerializeField] new Rigidbody2D rigidbody = null;
        [SerializeField] GameObject gfx = null;
        [Space]
        [SerializeField] float liveTime = 2;
        [SerializeField] float startVelocity = 3;
        [SerializeField] Vector3 velocityVector = Vector3.up;
        [Space]
        [SerializeField] bool penetration = false;
        [SerializeField] int damage = 5;

        float liveCountdown;
        bool active;

        public override void Destroy()
        {
            Deactivate();
            base.Destroy();
        }

        public override void Activate()
        {
            gfx.SetActive(true);
            rigidbody.simulated = true;
            active = true;
        }

        public override void Deactivate()
        {
            gfx.SetActive(false);
            rigidbody.simulated = false;
            active = false;
        }

        public override void Recreate()
        {
            liveCountdown = liveTime;
            Activate();
            rigidbody.velocity = transform.TransformDirection(velocityVector) * startVelocity;

        }

        private void Update()
        {
            if (active) {
                liveCountdown -= Time.deltaTime;
                if (liveCountdown <= 0) {
                    Destroy();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log($"Hitted {collision.gameObject}");

            var hittedActorHealth = collision.gameObject.GetComponentInParent<ActorHealth>();
            if (hittedActorHealth) {
                hittedActorHealth.Hit(damage);
            }

            if (!penetration) {
                Destroy();
            }
        }
    }
}
