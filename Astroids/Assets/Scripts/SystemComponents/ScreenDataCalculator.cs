using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [ExecuteInEditMode]
    public class ScreenDataCalculator : MonoBehaviour
    {
        [SerializeField] ScreenData loopData = null;
        [SerializeField] bool calculateInUpdate;
        private void Awake()
        {
            Calculate();
        }

        private void Update()
        {
            if (calculateInUpdate && loopData != null) {
                Calculate();
            }
        }

        [ContextMenu("Calculate")]
        private void Calculate()
        {
            Camera cam = CameraUtil.Main;
            var screenBL = cam.ScreenToWorldPoint(Vector3.zero);
            var screenTR = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

            loopData.ScreenLeft = screenBL.x;
            loopData.ScreenRight = screenTR.x;
            loopData.ScreenUp = screenTR.y;
            loopData.ScreenDown = screenBL.y;
        }
    } 
}
