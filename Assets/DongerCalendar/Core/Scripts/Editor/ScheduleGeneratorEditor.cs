using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine
{
	[CustomEditor(typeof(ScheduleGenerator))]
	public class ScheduleGeneratorEditor : Editor {
		public override void OnInspectorGUI()
		{
			EditorGUILayout.HelpBox("The schedule Generator is responsible for generating the schedule for an entire season.", MessageType.Info);
			DrawDefaultInspector();
		}
	}
}

