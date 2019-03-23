using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[CreateAssetMenu(menuName = "Accesors/Scene")]
	public class SceneAccesor : ScriptableObject
	{
		public string sceneName = "";

		public void ChangeToScene ()
		{
			ScenesController.Instance.ChangeScene(sceneName);
		}
	}
}

