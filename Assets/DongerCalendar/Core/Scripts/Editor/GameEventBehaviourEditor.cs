using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine
{
	[CustomEditor(typeof(GameEventBehaviour))]
	public class GameEventBehaviourEditor : Editor {

		GameEventBehaviour _gameEventBehaviour;

		/// <summary>
		/// This function is called when the object becomes enabled and active.
		/// </summary>
		void OnEnable()
		{
			_gameEventBehaviour = (GameEventBehaviour)target;
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			DrawDefaultInspector();

			if (GUILayout.Button("Simulate Game"))
			{
				_gameEventBehaviour.Simulate();
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}



