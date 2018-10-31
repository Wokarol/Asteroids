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
    void Update()
    {

        var ySecondaryPos = (2 * centreCam.orthographicSize);
        var xSecondaryPos = (2 * centreCam.orthographicSize * centreCam.aspect);
        var centrePos = centreCam.transform.position;

        SetCam(tCam,   0,  1, centrePos);
        SetCam(bCam,   0, -1, centrePos);
        SetCam(lCam,  -1,  0, centrePos);
        SetCam(rCam,   1,  0, centrePos);
        SetCam(tlCam, -1,  1, centrePos);
        SetCam(trCam,  1,  1, centrePos);
        SetCam(blCam, -1, -1, centrePos);
        SetCam(brCam,  1, -1, centrePos);


        void SetCam(Camera target, float x, float y, Vector3 centre)
        {
            var pos = target.transform.position;
            pos.x = xSecondaryPos * x;
            pos.y = ySecondaryPos * y;
            pos.z = 0;
            target.transform.position = pos + centre;

            target.orthographicSize = centreCam.orthographicSize;
        }
    }
}
