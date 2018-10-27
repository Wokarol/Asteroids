using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class PlayerInput : InputController
    {

        void Update()
        {
            Thrust = Mathf.Clamp01(Input.GetAxisRaw("Vertical"));
            Breaking = Mathf.Clamp01(-Input.GetAxisRaw("Vertical"));

            Rotate = Input.GetAxisRaw("Horizontal");

            Boost = Input.GetKey(KeyCode.LeftShift);
        }
    } 
}
