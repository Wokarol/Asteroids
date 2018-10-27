using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Wokarol.BetweenSceneManagment;

namespace Wokarol
{
    public class PlayerShipSpawner : MonoBehaviour
    {
        [SerializeField] BetweenSceneData betweenSceneData;
        [SerializeField] ShipsGroup ships;

        [SerializeField] SpawnEvent onPlayerSpawn;

        private void OnEnable()
        {
            var choosenShip = ships.GetShip(betweenSceneData.GetData("choosen_ship", 0));
            var _ob = Instantiate(choosenShip.shipPrefab, transform.position, Quaternion.identity);
            onPlayerSpawn.Invoke(_ob);
        }

        public void Spawn(int index)
        {
            var choosenShip = ships.GetShip(index);
            Instantiate(choosenShip.shipPrefab, transform.position, Quaternion.identity);
        }

        [System.Serializable]
        private class SpawnEvent : UnityEvent<GameObject>
        {
        }
    } 
}
