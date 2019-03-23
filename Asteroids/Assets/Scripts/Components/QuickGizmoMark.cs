using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class QuickGizmoMark : MonoBehaviour
    {
        public GizmoType type;
        public Color color = Color.red;

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            switch (type) {
                case GizmoType.plus:
                    Gizmos.DrawLine(transform.TransformPoint(Vector3.right * 0.5f), transform.TransformPoint(Vector3.left * 0.5f));
                    Gizmos.DrawLine(transform.TransformPoint(Vector3.up * 0.5f), transform.TransformPoint(Vector3.down * 0.5f));
                    break;
                case GizmoType.circle:
                    Gizmos.DrawWireSphere(transform.position, Mathf.Max(transform.localScale.x, transform.localScale.y) * 0.5f);
                    break;
                default:
                    break;
            }
        }

        public void SetGizmo(GizmoType type, Color color)
        {
            this.type = type;
            this.color = color;
        }

        public enum GizmoType
        {
            plus, circle
        }
    } 
}
