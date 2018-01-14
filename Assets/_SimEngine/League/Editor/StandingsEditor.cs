using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine{
	[CustomEditor(typeof(Standings))]
	public class StandingsEditor : Editor {

		Standings _standings;
		/// <summary>
		/// This function is called when the object becomes enabled and active.
		/// </summary>
		void OnEnable()
		{
			_standings = (Standings)target;
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.HelpBox("If there are any chances to the team configurations, then you need to refresh the team in the TeamFileReader ", MessageType.Info);
			EditorGUILayout.Space();
			
			DrawDefaultInspector();
		}
	}
}

