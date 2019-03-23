using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
    [ExecuteInEditMode]
    public class ScreenDataCalculator : MonoBehaviour
    {
        [SerializeField] Camera mainCamera = null;
        [SerializeField] ScreenData loopData = null;
        [SerializeField] bool calculateInUpdate = false;
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
            var screenBL = mainCamera.ScreenToWorldPoint(Vector3.zero);
            var screenTR = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

            loopData.ScreenLeft = screenBL.x;
            loopData.ScreenRight = screenTR.x;
            loopData.ScreenUp = screenTR.y;
            loopData.ScreenDown = screenBL.y;
        }
    } 
}
