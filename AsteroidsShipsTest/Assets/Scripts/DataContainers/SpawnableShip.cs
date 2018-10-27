using UnityEngine;

namespace Wokarol
{
    [CreateAssetMenu(menuName = "Spawnable Ship Data")]
    public class SpawnableShip : ScriptableObject
    {
        public string ID;
        public GameObject shipPrefab;
    }
}
