using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class FixedInput : InputController
    {
        [Range(0, 1)] [SerializeField] float thrust = 0;
        [Range(0, 1)] [SerializeField] float breaking = 0;
        [Range(-1, 1)] [SerializeField] float rotate = 0;
        [SerializeField] bool boost = false;
        [SerializeField] bool shoot = false;

        private void Start()
        {
            Thrust = thrust;
            Rotate = rotate;
            Breaking = breaking;

            Boost = boost;
            Shoot = shoot;
        }
    } 
}
