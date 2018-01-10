using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine{
	[CustomEditor(typeof(CalendarUIBuilder))]
	public class CalendarUIBuilderEditor : Editor{

		public override void OnInspectorGUI()
		{
			EditorGUILayout.HelpBox("The Calendar UI Builder will draw out the Calendar based off the event Manager.  Remember to drag in the Calendar GameObject into this.", MessageType.Info);
			DrawDefaultInspector();
		}
	}

}
