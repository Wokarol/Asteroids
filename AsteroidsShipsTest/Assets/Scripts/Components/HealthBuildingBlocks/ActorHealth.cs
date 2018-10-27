using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Wokarol
{
    public class ActorHealth : MonoBehaviour
    {
        [Header("Starting variables")]
        [FormerlySerializedAs("startingHealth")]
        [SerializeField] int maxHealth = 5;

        [Header("Set up")]
        [SerializeField] float invincibiltyTime = 0.1f;

        [Header("Events")]
        [SerializeField] UnityEvent onInvincibleFrameStart = new UnityEvent();
        [SerializeField] UnityEvent onInvincibleFrameStop = new UnityEvent();
        [Space]
        [SerializeField] UnityEvent onHit = new UnityEvent();

        int currentHealth;
        float invicibiltyCountdown = -1;
        bool invincible = false;

        private void Awake()
        {
            currentHealth = maxHealth;
        }

        private void Update()
        {
            if(invicibiltyCountdown > 0) {
                invicibiltyCountdown -= Time.deltaTime;
            } else if(invicibiltyCountdown <= 0 && invincible) {
                invincible = false;
                onInvincibleFrameStop.Invoke();
            }
        }

        public void Hit(int hitPoints)
        {
            if (!invincible) {
                Debug.Log($"{name} -> has been hitted");
                onHit.Invoke();

                currentHealth -= Mathf.Clamp(hitPoints, 0, int.MaxValue);

                invincible = true;
                onInvincibleFrameStart.Invoke();

                invicibiltyCountdown = invincibiltyTime;

                if (currentHealth <= 0) {
                    Debug.Log($"{name} -> have zero health");
                    GetComponent<IDestroyable>()?.Destroy();
                } 
            }
        }

        public void Heal(int healPoint)
        {
            currentHealth = Mathf.Clamp(currentHealth + healPoint, 0, maxHealth);
        }
    } 
}
