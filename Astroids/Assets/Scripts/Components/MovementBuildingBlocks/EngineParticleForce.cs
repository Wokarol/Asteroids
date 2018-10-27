using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [RequireComponent(typeof(ParticleSystem))]
    public class EngineParticleForce : MonoBehaviour
    {
        new ParticleSystem particleSystem = null;
        [SerializeField] Engine engine = null;
        [SerializeField] bool inverted = false;

        // ParticleSystem Settings
        float startLifetime = 0;

        private void Awake()
        {
            particleSystem = GetComponent<ParticleSystem>();
            startLifetime = particleSystem.main.startLifetimeMultiplier;
        }


        void Update()
        {
            var main = particleSystem.main;
            var force = Mathf.Lerp(0, startLifetime, engine.OutputForce * (inverted ? -1 : 1));
            main.startLifetimeMultiplier = force;

            if (force == 0 && particleSystem.isPlaying) {
                particleSystem.Stop(true);
            } else if (force > 0 && !particleSystem.isPlaying) {
                particleSystem.Play(true);
            }
        }
    }
}
