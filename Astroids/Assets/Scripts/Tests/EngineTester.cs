using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.TestTools
{
    public class EngineTester : Engine
    {
        [Range(0, 1)] [SerializeField] float engineForce = 0;
        [SerializeField] bool inverted = false;
        private void Update()
        {
            OutputForce = engineForce * (inverted ? -1 : 1);
        }
    }
}
