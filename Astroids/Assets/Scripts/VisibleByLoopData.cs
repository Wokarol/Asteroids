using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class VisibleByLoopData : MonoBehaviour
    {
        [SerializeField] ScreenData screenData = null;
        [SerializeField] GameObject[] visibleWhileXLooping = new GameObject[0];
        [SerializeField] GameObject[] visibleWhileYLooping = new GameObject[0];

        // Cache
        bool lastX = false, lastY = false;

        private void Start()
        {
            lastX = screenData.LoopX;
            foreach (var obj in visibleWhileXLooping) {
                obj.SetActive(lastX);
            }

            lastY = screenData.LoopY;
            foreach (var obj in visibleWhileYLooping) {
                obj.SetActive(lastY);
            }
        }

        private void Update()
        {
            if (lastX != screenData.LoopX) {
                lastX = screenData.LoopX;
                // On X changed
                foreach (var obj in visibleWhileXLooping) {
                    obj.SetActive(lastX);
                }
            }
            if (lastY != screenData.LoopY) {
                lastY = screenData.LoopY;
                // On Y changed
                foreach (var obj in visibleWhileYLooping) {
                    obj.SetActive(lastY);
                }
            }
        }
    } 
}
