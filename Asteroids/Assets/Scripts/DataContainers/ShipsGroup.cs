using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Wokarol
{
    [CreateAssetMenu]
    public class ShipsGroup : ScriptableObject
    {
        [SerializeField] PlayableShip[] ships = new PlayableShip[0];
        public int ShipCount => ships.Length;

        public PlayableShip GetShip(int index)
        {
            return ships[index];
        }

    }
}
