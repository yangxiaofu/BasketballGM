using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine{
    public class CalendarInspector : CalendarDrawer, ICalendarDrawer
    {
        private Calendar _calendar;
        ///<summary>The CalendarInspsector class is responsible for drawing on the inspector. The Behaviours changes which clicking the buttons.!--</summary>
		public CalendarInspector(Calendar calendar, GUISkin skin, int year, int month, int day, float buttonWidth){
			_calendar = calendar;
			_skin = skin;
			_year = year;
			_month = month;
			_day = day;
			_buttonWidth = buttonWidth;
		}
        public void Draw()
        {
			float columnWidth = _buttonWidth * 1.05f;
            //Get days in the month
            var daysInMonth = DateTime.DaysInMonth(_year, _month);

            //List out the days of the week.
            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < Calendar.DaysInWeek.Length; i++)
            {
                EditorGUILayout.LabelField(Calendar.DaysInWeek[i], GUILayout.Width(_buttonWidth));   
            }
            EditorGUILayout.EndHorizontal();

            //While there are still days left in the month.
            while (_day <= daysInMonth)
            {
                //Initializations
                var date = new DateTime(_year, _month, _day);
                var dayOfWeek = date.DayOfWeek;
                var dayOfWeekIndex = Calendar.GetDayOfWeekIndex(dayOfWeek);

				//Begin a new row.
                EditorGUILayout.BeginHorizontal();

                //Draw the empty slots where days to not exist.
                for (int i = 0; i < dayOfWeekIndex; i++)
                {
                    GUILayout.Box("", GUILayout.Width(_buttonWidth));
                }

                //Draw actual days
                for (int i = dayOfWeekIndex; i < 7; i++)
                {
                    EditorGUILayout.BeginVertical(GUILayout.Width(columnWidth));

                    //If the calendar contains an EventManager as a Component.
                    if (_calendar.EventManager)
                    {
                        //Refresh the search date.
                        var searchDate = new DateTime(_year, _month, _day);
                        var coreEvents = _calendar.EventManager.GetEvents(searchDate);
                        //Help the user visually determine if there are events on a particular day.
                        //If there are events, have a custom look to it. 
                        if (coreEvents.Count > 0){
                            GUILayout.Box(coreEvents.Count.ToString(), _skin.box, GUILayout.Width(_buttonWidth));
                        } 
                        //otherwise, just go with the default.  
                        else {
                            GUILayout.Box(coreEvents.Count.ToString(), GUILayout.Width(_buttonWidth));    
                        }
                    }
                    
					//If a day is selected, then update the calendar with the date. 
                    if(GUILayout.Button(_day.ToString(), GUILayout.Width(_buttonWidth)))
					{
                        //Update the calender monobehaviour
                        _calendar.UpdateCalendar(_year, _month, _day);
					}

                    EditorGUILayout.EndVertical();

                    _day++;

                    //If not more days exist in the month, then do not continue to add days.
                    if (_day > daysInMonth) break;
                }

                EditorGUILayout.EndHorizontal();
            }
        }
    }

}
