using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine{
	[CustomEditor(typeof(Calendar))]
	public class CalendarEditor : Editor {
		Calendar _calendar;
		public int Year;
		public int Month;
		private int _day;
		 ///<summary>Ensures that the window is only opened once.</summary>
        public bool MonthWindowOpen = false;
        ///<summary>Ensures that the Year Window is only opened once</summary>
        public bool YearWindowOpen = false;
		
        GUISkin _skin;
        string _path = "Assets/DongerCalendar/Core/GUISkin/GUISkin.guiskin";
        

		protected virtual void DrawHelpBox()
        {
            EditorGUILayout.HelpBox(_calendar.HelpBox(), MessageType.Info);
        }

		protected virtual void OnEnable()
		{
			_calendar = (Calendar)target;
			Year = serializedObject.FindProperty("StartingYear").intValue;
			Month = serializedObject.FindProperty("StartingMonth").intValue;
			_day = serializedObject.FindProperty("StartingDay").intValue;
            _skin = (GUISkin)(AssetDatabase.LoadAssetAtPath(_path, typeof(GUISkin)));
		}

		public override void OnInspectorGUI()
        {
            serializedObject.Update();

            //Draw the help box
            DrawHelpBox();

            //Display the Calendar header
            GUILayout.Label("Calendar", EditorStyles.boldLabel);

            if (GUILayout.Button("Reset To Default"))
            {
                Calendar calender = (Calendar)_calendar;
                Year = calender.StartingYear;
                Month = calender.StartingMonth;
                _day = calender.StartingDay;
                _calendar.ResetToDefault();
                return;
            }

            //Draw the selectors
            DrawYearSelector();
            DrawMonthSelector();

            Seperator();

            //Draw the selected date
            DrawSelectedDate();

            //Draw the calendar for the inspector.
            float buttonWidth = 50f;
            var calenderInspector = new CalendarInspector(_calendar, _skin, Year, Month, _day, buttonWidth);
            var calendarDrawer = new CalendarDrawerEditor(calenderInspector);
            calendarDrawer.Draw();

            EditorGUILayout.Space();

            DrawDefaultInspector();

            serializedObject.ApplyModifiedProperties();
        }

        ///<summary>Draws the selected date to notify the user.!--</summary>
        protected virtual void DrawSelectedDate()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Selected Date", EditorStyles.boldLabel, GUILayout.Width(100));
            var selectedDate = _calendar.SelectedDate.Month + "/" + _calendar.SelectedDate.Day + "/" + _calendar.SelectedDate.Year;
            EditorGUILayout.LabelField(selectedDate);
            EditorGUILayout.EndHorizontal();
        }

        protected virtual void DrawYearSelector()
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("<<"))
            {
                DecreaseYear();
            }

            if (GUILayout.Button(Year.ToString(), GUILayout.Width(300)))
            {
                if (!YearWindowOpen)
                {
                    YearWindowOpen = true;
                    YearListEditorWindow window = ScriptableObject.CreateInstance<YearListEditorWindow>();
                    window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 500);
                    window.Show();
                    var columns = 5;
                    var buttonWidth = 50;
                    window.Setup(this, columns, buttonWidth);
                    window.Year = this.Year;
                }
            }

            if (GUILayout.Button(">>"))
            {
                IncreaseYear();
            }
            EditorGUILayout.EndHorizontal();
        }

		protected virtual void DrawMonthSelector()
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("<<"))
            {
                DecreaseMonth();
            }

            if (GUILayout.Button(Calendar.Months[Month - 1].ToString(), GUILayout.Width(300)))
            {
                if (!MonthWindowOpen)
                {
                    MonthWindowOpen = true;

                    //Open Window
                    MonthListEditorWindow window = ScriptableObject.CreateInstance<MonthListEditorWindow>();
                    window.position = new Rect(Screen.width / 2, Screen.height / 2, 500, 125);
                    window.Show();
                    var columns = 5;
                    var buttonWidth = 50;
                    window.Setup(this, columns, buttonWidth);
                }
            }

            if (GUILayout.Button(">>"))
            {
                IncreaseMonth();
            }
            EditorGUILayout.EndHorizontal();
        }

		///<summary> Separator</summary>
		protected virtual void Seperator()
        {
            EditorGUILayout.Space();
            EditorGUILayout.Separator();
        }

        protected virtual void DecreaseMonth()
        {
            Month -= 1;
            if (Month == 0){
                Month = 12;
            }
        }

        protected virtual void IncreaseMonth()
        {
            Month += 1;
            if (Month == 13){
                Month = 1;
            }
        }

        protected virtual void IncreaseYear()
        {
            Year += 1;
        }

        protected virtual void DecreaseYear()
        {
            Year -= 1;
        }
	}

}
