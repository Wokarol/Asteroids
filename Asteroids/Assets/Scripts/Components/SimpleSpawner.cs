using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class SimpleSpawner : MonoBehaviour
    {
        [SerializeField] GameObject objectPrefab = null;
        [SerializeField] ScreenData screenData = null;
        [SerializeField] Vector2 safeZone = Vector2.zero;

        public void SpawnNotReturn()
        {
            Spawn();
        }

        public GameObject Spawn()
        {
            var pos = new Vector3(
                (screenData.ScreenLeft + safeZone.x) + (screenData.ScreenX - safeZone.x * 2) * Random.value,
                (screenData.ScreenDown + safeZone.y) + (screenData.ScreenY - safeZone.y * 2) * Random.value
                );


            Debug.DrawLine(pos + Vector3.left, pos + Vector3.right, Color.green, 10f);
            Debug.DrawLine(pos + Vector3.up, pos + Vector3.down, Color.green, 10f);
            return Instantiate(objectPrefab, pos, Quaternion.identity);
        }

        private void OnDrawGizmosSelected()
        {
            if(screenData == null) {
                return;
            }

            var BL = new Vector2(
                screenData.ScreenLeft + safeZone.x,
                screenData.ScreenDown + safeZone.y
                );
            var TR = new Vector2(
                BL.x + screenData.ScreenX - safeZone.x * 2,
                BL.y + screenData.ScreenY - safeZone.y * 2
                );


            var BR = new Vector2(TR.x, BL.y);
            var TL = new Vector2(BL.x, TR.y);

            Gizmos.DrawLine(BL, TR);
            Gizmos.DrawLine(TL, BR);

            Gizmos.DrawLine(TL, TR);
            Gizmos.DrawLine(BL, BR);

            Gizmos.DrawLine(TL, BL);
            Gizmos.DrawLine(BR, TR);
        }
    } 
}
