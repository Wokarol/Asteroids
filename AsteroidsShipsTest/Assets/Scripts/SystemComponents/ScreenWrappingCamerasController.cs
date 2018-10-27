using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrappingCamerasController : MonoBehaviour
{
    [SerializeField] Camera centreCam = null;
    [Space]
    [SerializeField] Camera tCam = null;
    [SerializeField] Camera bCam = null, lCam = null, rCam = null, tlCam = null, trCam = null, blCam = null, brCam = null;

    // Start is called before the first frame update
    [ContextMenu("SetCams")]
    void Start()
    {
        var ySecondaryPos = 2 * centreCam.orthographicSize;
        var xSecondaryPos = 2 * centreCam.orthographicSize * centreCam.aspect;

        SetCam(tCam,   0,  1);
        SetCam(bCam,   0, -1);
        SetCam(lCam,  -1,  0);
        SetCam(rCam,   1,  0);
        SetCam(tlCam, -1,  1);
        SetCam(trCam,  1,  1);
        SetCam(blCam, -1, -1);
        SetCam(brCam,  1, -1);


        void SetCam(Camera target, float x, float y)
        {
            var pos = target.transform.position;
            pos.x = xSecondaryPos * x;
            pos.y = ySecondaryPos * y;
            target.transform.position = pos;

            target.orthographicSize = centreCam.orthographicSize;
        }
    }
}
