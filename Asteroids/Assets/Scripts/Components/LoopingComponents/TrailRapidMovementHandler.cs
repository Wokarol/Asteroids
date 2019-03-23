using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [RequireComponent(typeof(TrailRenderer))]
    public class TrailRapidMovementHandler : MonoBehaviour
    {
        //[SerializeField] private float distanceTreshhold = 5;
        //Vector3 prevPos;

        TrailRenderer trail;

        private void Awake()
        {
            trail = GetComponent<TrailRenderer>();
        }

        //void LateUpdate()
        //{
        //    if (Vector2.Distance(transform.position, prevPos) > distanceTreshhold) {
        //        var motionVector = transform.position - prevPos;
        //        var points = new Vector3[trail.positionCount];
        //        trail.GetPositions(points);
        //        for (int i = 0; i < points.Length; i++) {
        //            points[i] += motionVector;
        //        }
        //        Debug.Log($"There are {points.Length} points");
        //        trail.SetPositions(points);
        //    }

        //    prevPos = transform.position;
        //}

        public void MoveTrail(Vector3 motionVector)
        {
            var points = new Vector3[trail.positionCount];
            trail.GetPositions(points);
            for (int i = 0; i < points.Length; i++) {
                points[i] += motionVector;
            }
            trail.SetPositions(points);
        }

    }
}
