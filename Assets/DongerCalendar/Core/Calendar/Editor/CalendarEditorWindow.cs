using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine{
	public class CalendarEditorWindow : EditorWindow 
	{
		private ScheduleGenerator _scheduleGenerator;
		private GUISkin _skin;
		
		public void Setup(ScheduleGenerator scheduleGenerator, GUISkin skin)
		{
			_scheduleGenerator = scheduleGenerator;
			_skin = skin;
		}

		/// <summary>
		/// OnGUI is called for rendering and handling GUI events.
		/// This function can be called multiple times per frame (one call per event).
		/// </summary>
		void OnGUI()
		{
			var calendarWindow = new CalendarWindow(_scheduleGenerator, _skin, 2018, 1, 1, 25f);
			var cal = new CalendarDrawerEditor(calendarWindow);
			cal.Draw();
		}
	}
}

