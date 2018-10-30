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
        float startLifetimeMin = 0;
        float startLifetimeMax = 0;

        private void Awake()
        {
            particleSystem = GetComponent<ParticleSystem>();
            startLifetimeMin = particleSystem.main.startLifetime.constantMin;
            startLifetimeMax = particleSystem.main.startLifetime.constantMax;
        }


        void Update()
        {
            var main = particleSystem.main;
            var forceMin = Mathf.Lerp(0, startLifetimeMin, engine.OutputForce * (inverted ? -1 : 1));
            var forceMax = Mathf.Lerp(0, startLifetimeMax, engine.OutputForce * (inverted ? -1 : 1));
            var lifetimeMinMax = main.startLifetime;
            lifetimeMinMax.constantMin = forceMin;
            lifetimeMinMax.constantMax = forceMax;
            main.startLifetime = lifetimeMinMax;

            if (engine.OutputForce == 0 && particleSystem.isPlaying) {
                particleSystem.Stop(true);
            } else if (engine.OutputForce > 0 && !particleSystem.isPlaying) {
                particleSystem.Play(true);
            }

            //Debug.Log($"{name} -> Force: {forceMin} <> {forceMax} , constant: {main.startLifetime.constant}");
        }
    }
}
