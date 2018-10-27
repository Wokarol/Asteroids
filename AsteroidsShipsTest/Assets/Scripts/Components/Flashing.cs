using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class Flashing : MonoBehaviour
    {
        [SerializeField] bool flashing = false;
        [SerializeField] float timeBetweenFlashes = 0.1f;
        [Space]
        [SerializeField] SpriteRenderer[] spriteRenderers = new SpriteRenderer[0];

        bool isInFlashState = false;
        float timeBetweenFlashesCountdown = -1;

        void Update()
        {
            if (timeBetweenFlashesCountdown > 0) {
                timeBetweenFlashesCountdown -= Time.deltaTime;
            } else if (timeBetweenFlashesCountdown <= 0 && flashing) {
                SwitchState();
                timeBetweenFlashesCountdown = timeBetweenFlashes;
            }
        }

        void SwitchState()
        {
            if (isInFlashState) {
                SetAlphas(1);
                isInFlashState = false;
            } else {
                SetAlphas(0.8f);
                isInFlashState = true;
            }
        }

        void SetAlphas(float state)
        {
            foreach (var spriteRenderer in spriteRenderers) {
                var color = spriteRenderer.color;
                color.a = state;
                spriteRenderer.color = color;
            }
        }

        public void StartFlashing()
        {
            flashing = true;
        }
        public void StopFlashing()
        {
            flashing = false;
            timeBetweenFlashesCountdown = -1;
            SetAlphas(1);
            isInFlashState = false;
        }
    }

}