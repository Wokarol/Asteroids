using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wokarol
{
    public class ScreenLooper : MonoBehaviour
    {
        [SerializeField] ScreenData loopData = null;
        [SerializeField] ScreenTeleportEvent screenTeleportEvent = new ScreenTeleportEvent();

        [Header("Colliders")]
        [SerializeField] bool loopCollider = false;
        [SerializeField] Collider2D originalCollider = null;
        [SerializeField] string primaryColliderLayer = "";
        [SerializeField] string secondaryColliderLayer = "";
        ColliderClone[] colliderClones;


        private void Start()
        {
            if (loopCollider) {
                CreateLoopColliders();
            }
        }

        private void CreateLoopColliders()
        {


            if (originalCollider == null) { Debug.LogError("There's no original Collider setted"); return; }

            var offsetVector = new Vector3(loopData.ScreenRight - loopData.ScreenLeft, loopData.ScreenUp - loopData.ScreenDown, 0);
            var collidersList = new List<ColliderClone>();

            for (int x = -1; x <= 1; x++) {
                for (int y = -1; y <= 1; y++) {
                    if (!(y == 0 && x == 0)) {

                        var _obj = new GameObject($"Collider Clone [{x}, {y}]");
                        var _transform = _obj.transform;
                        _transform.localScale = originalCollider.transform.localScale;
                        _transform.SetParent(this.transform);

                        var _col = CopyComponent(originalCollider, _obj);

                        var _gizmos = _obj.AddComponent<QuickGizmoMark>();
                        _gizmos.SetGizmo(QuickGizmoMark.GizmoType.circle, new Color(1, 1, 0.5f, 1));

                        if ((x == -1 && y == 0) || (x == -1 && y == -1) || (x == 0 && y == -1) || (x == 1 && y == -1)) {
                            // Primary colliders
                            _obj.name += $" (Main)";
                            _gizmos.color = new Color(0, 0.9f, 1, 1);
                            _obj.layer = LayerMask.NameToLayer(primaryColliderLayer);
                        } else {
                            // Secondary colliders
                            _obj.layer = LayerMask.NameToLayer(secondaryColliderLayer);
                        }

                        _transform.position = transform.position + new Vector3(offsetVector.x * x, offsetVector.y * y);
                        collidersList.Add(new ColliderClone(_obj, _col));
                    }
                }
            }
        }

        private void LateUpdate()
        {
            CheckLoop();
        }

        void CheckLoop()
        {
            if (loopData.LoopX) {
                if (transform.position.x > loopData.ScreenRight) {
                    // Right
                    Jump(new Vector3(loopData.ScreenLeft - loopData.ScreenRight, 0, 0));
                    return;
                }
                if (transform.position.x < loopData.ScreenLeft) {
                    // Left
                    Jump(new Vector3(loopData.ScreenRight - loopData.ScreenLeft, 0, 0));
                    return;
                }
            }

            if (loopData.LoopY) {
                if (transform.position.y > loopData.ScreenUp) {
                    // Up
                    Jump(new Vector3(0, loopData.ScreenDown - loopData.ScreenUp, 0));
                    return;
                }
                if (transform.position.y < loopData.ScreenDown) {
                    // Down
                    Jump(new Vector3(0, loopData.ScreenUp - loopData.ScreenDown, 0));
                    return;
                }
            }
        }

        void Jump(Vector3 motionVector)
        {
            screenTeleportEvent.Invoke(motionVector);
            transform.position += motionVector;
        }

        T CopyComponent<T>(T original, GameObject destination) where T : Component
        {
            System.Type type = original.GetType();
            Component copy = destination.AddComponent(type);
            System.Reflection.FieldInfo[] fields = type.GetFields();
            foreach (System.Reflection.FieldInfo field in fields) {
                field.SetValue(copy, field.GetValue(original));
            }
            return copy as T;
        }

        [System.Serializable]
        class ScreenTeleportEvent : UnityEvent<Vector3> { }

        private class ColliderClone
        {
            GameObject gameObject;
            Collider2D collider;

            public ColliderClone(GameObject gameObject, Collider2D collider)
            {
                this.gameObject = gameObject;
                this.collider = collider;
            }
        }
    }
}
