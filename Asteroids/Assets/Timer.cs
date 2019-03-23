using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] UnityEvent onTimer = new UnityEvent();
        [SerializeField] float time = 1;
        float countdown;
        private bool running;
        public bool IsRunning { get => running;}

        public void StartTimer()
        {
            countdown = time;
            running = true;
        }

        public void StopTimer()
        {
            running = false;
        }
        public void ResumeTimer()
        {
            running = true;
        }

        public void TriggerTimer()
        {
            countdown = -1;
            running = false;
            OnTimerTrigger();
        }

        void OnTimerTrigger()
        {
            onTimer.Invoke();
        }

        private void Update()
        {
            if (running) {
                countdown -= Time.deltaTime;
                if(countdown <= 0) {
                    TriggerTimer();
                }
            }
        }
    } 
}
