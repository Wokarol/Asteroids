using UnityEngine;

namespace Wokarol
{
    [CreateAssetMenu]
    internal class ScreenData : ScriptableObject
    {
        [Header("Size")]
        public float ScreenLeft = 0;
        public float ScreenRight = 0;
        public float ScreenUp = 0;
        public float ScreenDown = 0;

        public float ScreenX { get => ScreenRight - ScreenLeft; }
        public float ScreenY { get => ScreenUp - ScreenDown; }

        [Header("Looping")]
        public bool LoopX;
        public bool LoopY;

        public void SetLoopX(bool state) { LoopX = state; }
        public void SetLoopY(bool state) { LoopY = state; }
    } 
}