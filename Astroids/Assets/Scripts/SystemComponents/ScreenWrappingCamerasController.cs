using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    public class ScreenWrappingCamerasController : MonoBehaviour
    {
        [SerializeField] Camera centreCam = null;
        [SerializeField] ScreenData loopData;

        [Header("Editor")]
        [SerializeField] LayerMask loopCamLayerMask = int.MaxValue;

        Camera tCam = null, bCam = null, lCam = null, rCam = null, tlCam = null, trCam = null, blCam = null, brCam = null;

        private void Start()
        {
            SetUp();
        }

        void Update()
        {
            var ySecondaryPos = (2 * centreCam.orthographicSize);
            var xSecondaryPos = (2 * centreCam.orthographicSize * centreCam.aspect);
            var centrePos = centreCam.transform.position;

            SetCam(tCam, 0, 1, centrePos, () => loopData.LoopY);
            SetCam(bCam, 0, -1, centrePos, () => loopData.LoopY);
            SetCam(lCam, -1, 0, centrePos, () => loopData.LoopX);
            SetCam(rCam, 1, 0, centrePos, () => loopData.LoopX);
            SetCam(tlCam, -1, 1, centrePos, () => loopData.LoopX && loopData.LoopY);
            SetCam(trCam, 1, 1, centrePos, () => loopData.LoopX && loopData.LoopY);
            SetCam(blCam, -1, -1, centrePos, () => loopData.LoopX && loopData.LoopY);
            SetCam(brCam, 1, -1, centrePos, () => loopData.LoopX && loopData.LoopY);


            void SetCam(Camera target, float x, float y, Vector3 centre, System.Func<bool> visibleDelegate)
            {
                if (visibleDelegate()) {
                    target.gameObject.SetActive(true);
                    var pos = target.transform.position;
                    pos.x = xSecondaryPos * x;
                    pos.y = ySecondaryPos * y;
                    pos.z = 0;
                    target.transform.position = pos + centre;
                    target.orthographicSize = centreCam.orthographicSize;
                } else {
                    target.gameObject.SetActive(false);
                }
            }
        }

        void SetUp()
        {
            CreateCam(ref tCam, "T");
            CreateCam(ref bCam, "B");
            CreateCam(ref lCam, "L");
            CreateCam(ref rCam, "R");
            CreateCam(ref tlCam, "TL");
            CreateCam(ref trCam, "TR");
            CreateCam(ref blCam, "BL");
            CreateCam(ref brCam, "BR");

            void CreateCam(ref Camera camera, string nameSufix)
            {
                var obj = new GameObject($"LoopCam_{nameSufix}");
                obj.transform.parent = this.transform;
                var cam = obj.AddComponent<Camera>();
                cam.clearFlags = CameraClearFlags.Nothing;
                cam.cullingMask = loopCamLayerMask;
                cam.depth = 5;
                cam.orthographic = true;
                camera = cam;
            }
        }
    } 
}
