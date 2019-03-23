using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wokarol;

public class RandomInput : InputController
{
    [Range(0, 1)] [SerializeField] float thrust = 0;

    //[SerializeField] bool boost = false;
    //[SerializeField] bool shoot = false;
    [Space]
    [SerializeField] MinMax rotationPower = new MinMax(-0.5f, 0.5f);
    [Space]
    [SerializeField] MinMax timeBetweenRotations = new MinMax(1.8f, 2.2f);
    [SerializeField] MinMax rotationTime = new MinMax(0.3f, 0.8f);

    float countdown;
    RandomState randomState = RandomState.Waiting;

    private void Start()
    {
        Thrust = thrust;
        countdown = Random.Range(timeBetweenRotations.Min, timeBetweenRotations.Max);
    }

    private void Update()
    {
        if(countdown < 0 && randomState == RandomState.Waiting) {
            countdown = Random.Range(rotationTime.Min, rotationTime.Max);
            randomState = RandomState.Rotating;
            Rotate = Random.Range(rotationPower.Min, rotationTime.Max);
        } else if (countdown < 0 && randomState == RandomState.Rotating) {
            countdown = Random.Range(timeBetweenRotations.Min, timeBetweenRotations.Max);
            randomState = RandomState.Waiting;
            Rotate = 0;
        }

        countdown -= Time.deltaTime;
    }

    [System.Serializable]
    private class MinMax
    {
        public float Min;
        public float Max;

        public MinMax(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }

    private enum RandomState
    {
        Waiting,
        Rotating
    }
}
