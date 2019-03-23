using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class SimpleDestroy : MonoBehaviour, IDestroyable
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
