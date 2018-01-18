using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine
{
	[CustomEditor(typeof(ScheduleGenerator))]
	public class ScheduleGeneratorEditor : Editor {
		SerializedProperty _startYearProp;
		SerializedProperty _startMonthProp;
		SerializedProperty _startDayProp;
		SerializedProperty _endYearProp;
		SerializedProperty _endMonthProp;
		SerializedProperty _endDayProp;

		ScheduleGenerator _scheduleGenerator;
		/// <summary>
		/// This function is called when the object becomes enabled and active.
		/// </summary>
		void OnEnable()
		{
			_scheduleGenerator = (ScheduleGenerator)target;
			_startYearProp = serializedObject.FindProperty("StartYear");
			_startMonthProp = serializedObject.FindProperty("StartMonth");
			_startDayProp = serializedObject.FindProperty("StartDay");
			_endDayProp = serializedObject.FindProperty("EndDay");
			_endMonthProp = serializedObject.FindProperty("EndMonth");
			_endYearProp = serializedObject.FindProperty("EndYear");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			EditorGUILayout.HelpBox("The schedule Generator is responsible for generating the schedule for an entire season.", MessageType.Info);

			if (GUILayout.Button("Select Start Date"))
			{
				CalendarEditorWindow editorWindow = ScriptableObject.CreateInstance<CalendarEditorWindow>();
				editorWindow.position = new Rect(Screen.width / 2, Screen.height / 2, 500, 125);
				editorWindow.Show();
				editorWindow.Setup(_scheduleGenerator, _scheduleGenerator.Skin);
			}

			//Display the start date that is selected.
			EditorGUILayout.PropertyField(_startYearProp);
			EditorGUILayout.PropertyField(_startMonthProp);
			EditorGUILayout.PropertyField(_startDayProp);

			EditorGUILayout.Space();

			//Select the end date. 
			if (GUILayout.Button("Select End Date"))
			{
				Debug.Log("The end of when the events will be selected");
			}

			//Display the end date that is selected.
			EditorGUILayout.PropertyField(_endYearProp);
			EditorGUILayout.PropertyField(_endMonthProp);
			EditorGUILayout.PropertyField(_endDayProp);

			EditorGUILayout.HelpBox("The number of events between the start date and the end date", MessageType.Info);
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.TextField("1");
			EditorGUILayout.TextField("1");
			EditorGUILayout.EndHorizontal();

			serializedObject.ApplyModifiedProperties();
		}
	}
}

