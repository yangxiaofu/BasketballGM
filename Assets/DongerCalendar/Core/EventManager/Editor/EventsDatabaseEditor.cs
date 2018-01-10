using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine{
	[CustomEditor(typeof(EventsDatabase))]
	public class EventsDatabaseEditor : Editor 
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			EditorUtility.SetDirty((EventsDatabase)target);
			DrawDefaultInspector();
			serializedObject.ApplyModifiedProperties();
		}
	}
}

