using UnityEngine;
using System.Collections;

namespace Wokarol
{
    [CreateAssetMenu]
    public class ShipsGroup : ScriptableObject
    {
        [SerializeField] SpawnableShip[] ships = new SpawnableShip[0];
        public SpawnableShip[] Ships { get => ships; }
    } 
}
