using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Wokarol
{
    [CreateAssetMenu]
    public class ShipsGroup : ScriptableObject
    {
        [SerializeField] SpawnableShip[] ships = new SpawnableShip[0];

        public SpawnableShip GetShip(int index)
        {
            return ships[index];
        }
    }
}
