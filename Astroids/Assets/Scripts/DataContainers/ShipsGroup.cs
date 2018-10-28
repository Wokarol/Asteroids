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
        public int ShipCount => ships.Length;

        public SpawnableShip GetShip(int index)
        {
            return ships[index];
        }

    }
}
