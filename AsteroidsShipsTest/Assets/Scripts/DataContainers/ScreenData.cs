using UnityEngine;

namespace Wokarol
{
    [CreateAssetMenu]
    internal class ScreenData : ScriptableObject
    {
        public float ScreenLeft = 0;
        public float ScreenRight = 0;
        public float ScreenUp = 0;
        public float ScreenDown = 0;

        public float ScreenX { get => ScreenRight - ScreenLeft; }
        public float ScreenY { get => ScreenUp - ScreenDown; }
    } 
}