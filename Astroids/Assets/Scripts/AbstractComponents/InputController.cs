using UnityEngine;

namespace Wokarol
{
    public abstract class InputController : MonoBehaviour
    {
        public float Thrust { get; protected set; }
        public float Breaking { get; protected set; }
        public float Rotate { get; protected set; }

        public bool Boost { get; protected set; }
    }
}