using UnityEngine;

namespace Wokarol
{
    [CreateAssetMenu(menuName = "Spawnable Ship Data")]
    public class PlayableShip : ScriptableObject
    {
        public string ID;
        public string ShipName;
        public GameObject shipPrefab;
    }
}
