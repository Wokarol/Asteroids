using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.TestTools
{
    public class EngineTester : Engine
    {
        [Range(0, 1)] [SerializeField] float engineForce;
        [SerializeField] bool inverted;
        private void Update()
        {
            OutputForce = engineForce * (inverted ? -1 : 1);
        }
    }
}
