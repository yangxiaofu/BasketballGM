using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Donger.BuckeyeEngine{
	public class CalendarUIBuilder : UIBuilder
	{
        [Header("Calendar UI Builder Specific")]
		[SerializeField] Calendar _calendar;
		protected virtual void Start()
        {
            //Find the calendar component.
            if (!_calendar) Debug.LogError("You need to reference the calendar in " + this.gameObject.name);

            SetupParentTransform();
            ClearCalendarUI();
            BuildCalendarUI(_calendar.SelectedDate, _preferredWidth);
        }

        ///<summary>This clears the calendar UI parent transform and prepares it to be buitlt again</summary>
        protected virtual void ClearCalendarUI()
        {
            foreach (Transform child in _uiParentTransform)
            {
                Destroy(child.gameObject);
            }
        }

        ///<summary>Builds the Calendar UI in the game.</summary>
        protected virtual void BuildCalendarUI(Date date, float columnWidth)
        {
            var day = date.Day; 
			var daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);

            GenerateMonthHeader(Calendar.Months[date.Month - 1], CreateUIRow("Row", _uiParentTransform).transform);
            GenerateWeeksHeader();
			
			//Iterate thru each day of the month.
			while (day <= daysInMonth)
			{
				//Generate each row for the calendar.
            	var row = CreateUIRow("Row", _uiParentTransform);

                //Used to separate teh date time fromt he previous reference.
                var dateTime = new DateTime(date.Year, date.Month, day); 
				var dayOfWeek = dateTime.DayOfWeek;
                var dayOfWeekIndex = Calendar.GetDayOfWeekIndex(dayOfWeek);

				//Draw the empty UI slots for days that don't exist.
				for (int i = 0; i < dayOfWeekIndex; i++)
                {
                    BuildCell("Empty", row.transform, _emptyBackground, _daysTextAnchor);
                }

                //Draw the actual UI days
                for (int i = dayOfWeekIndex; i < 7; i++)
				{
                    //If days exist, then continue to draw the cell.
					if (day <= daysInMonth)
                    {
                        BuildCell(day.ToString(), row.transform, _hasActivitiesBackground, _daysTextAnchor);
						day++;
					} 
                    //Otherwise, draw the blank days at teh end of the month, then break when it's over.
                    else {
                        BuildCell("Empty", row.transform, _emptyBackground, _daysTextAnchor);
					}
				}

				if (day > daysInMonth) break; //When days are over, then break from this method.
			}
        }

        ///<summary>Back a month</summary>
        private void BackAMonth()
        {   
            _calendar.BackMonth();
            ClearCalendarUI();
            BuildCalendarUI(_calendar.SelectedDate, _preferredWidth);
        }

        ///<summary>Forward a month</summary>
        private void ForwardAMonth()
        {
            _calendar.ForwardMonth();
            ClearCalendarUI();
            BuildCalendarUI(_calendar.SelectedDate, _preferredWidth);
        }

        ///<summary>This will have the month information and buttons that you can use to scroll in different direction</summary>
        private void GenerateMonthHeader(string monthName, Transform parent)
        {
            var row = CreateUIRow("Row", parent);

            //Generate the back button. 
            CreateUIButton("Back", row.transform, BackAMonth);
            
            BuildCell(monthName, row.transform, _emptyBackground, _titleTextAnchor);

            //This generates the forward month button. 
            CreateUIButton("Forward", row.transform, ForwardAMonth);
        }

        ///<summary>Create the header for days of the week. </summary>
        protected virtual void GenerateWeeksHeader()
        {
            var row = CreateUIRow("Row", _uiParentTransform);

            for (int i = 0; i < Calendar.DaysInWeek.Length; i++)
            {
                BuildCell(Calendar.DaysInWeek[i].ToString(), row.transform, _hasActivitiesBackground, _daysTextAnchor);
            }
        }

    }
}

