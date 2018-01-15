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
			DrawDefaultInspector();
			EditorUtility.SetDirty((EventsDatabase)target);
			serializedObject.ApplyModifiedProperties();
		}
	}
}

