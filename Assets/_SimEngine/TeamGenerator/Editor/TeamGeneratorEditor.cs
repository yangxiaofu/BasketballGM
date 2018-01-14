using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine{
	[CustomEditor(typeof(TeamGenerator))]
	public class TeamGeneratorEditor : Editor{

		TeamGenerator _teamGenerator;

		/// <summary>
		/// This function is called when the object becomes enabled and active.
		/// </summary>
		void OnEnable()
		{
			_teamGenerator = (TeamGenerator)target;	
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.HelpBox("This component is used to generate your teams.", MessageType.Info);

			if (GUILayout.Button("Generate Teams"))
			{
				_teamGenerator.GenerateTeams();
			}

			if (GUILayout.Button("Clear Teams"))
			{
				_teamGenerator.ClearTeams();
			}

			DrawDefaultInspector();


			serializedObject.ApplyModifiedProperties();
		}
	}

}
