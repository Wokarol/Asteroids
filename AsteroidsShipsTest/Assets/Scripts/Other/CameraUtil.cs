using UnityEngine;

namespace Wokarol
{
    internal static class CameraUtil
    {
        static Camera main;
        static public Camera Main
        {
            get
            {
                if(main == null)
                {
                    main = Camera.main;
                }
                return main;
            }
        }


    }
}