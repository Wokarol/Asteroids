using UnityEngine;
using System.Collections;

namespace Wokarol
{
    [CreateAssetMenu]
    public class ShipsGroup : ScriptableObject
    {
        [SerializeField] SpawnableShip[] ships;
        public SpawnableShip[] Ships { get => ships; }
    } 
}
