using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CommandTerminal;
using UnityEngine.SceneManagement;

namespace Wokarol.TerminalCommands
{
	public static class TerminalCommands
	{
		[RegisterCommand("Scenes", Help = "Show all loaded scenes", MaxArgCount = 0)]
		public static void ShowScenes (CommandArg[] args)
		{
			string text = "Loaded scenes:";
			for (int i = 0; i < SceneManager.sceneCount; i++) {
				var scene = SceneManager.GetSceneAt(i);
				text += $"\n\t{scene.name}";
			}
			Debug.Log(text);
		}
	}
}

