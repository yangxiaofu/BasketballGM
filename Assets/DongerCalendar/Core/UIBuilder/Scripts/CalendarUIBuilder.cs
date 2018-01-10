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
                var dateTime = new DateTime(date.Year, date.Month, day); //Used to separate teh date time fromt he previous reference.
				var dayOfWeek = dateTime.DayOfWeek;
                var dayOfWeekIndex = Calendar.GetDayOfWeekIndex(dayOfWeek);

				//Draw the empty UI slots for days that don't exist.
				for (int i = 0; i < dayOfWeekIndex; i++)
                {
                    BuildCell("Empty", row.transform);
                }

                //Draw the actual UI days
                for (int i = dayOfWeekIndex; i < 7; i++)
				{
                    //If days exist, then continue to draw the cell.
					if (day <= daysInMonth)
                    {
                        BuildCell(day.ToString(), row.transform);
						day++;
					} 
                    //Otherwise, draw the blank days at teh end of the month, then break when it's over.
                    else {
                        BuildCell("Empty", row.transform);
					}
				}

				if (day > daysInMonth) break; //When days are over, then break from this method.
			}
        }

        ///<summary>Builds UI the cell.  </summary>
        ///<param name="cellName">The name of the cell.  </param>
        ///<param name="parent">The parent the cell resides under.  </param>
        private void BuildCell(string cellName, Transform parent)
        {
            var cellBuilder = new CellBuilder(cellName);
            cellBuilder.SetFont(_font);
            cellBuilder.SetTextAnchor(TextAnchor.MiddleCenter);
            cellBuilder.SetLayoutElement(_preferredHeight, _preferredWidth);

            float opacity = 0f;
            cellBuilder.SetBackgroundImage(_uiBackground, opacity);
            cellBuilder.SetParent(parent);

            DongerUI.CellBuilderHandler cellBuilderHandler = cellBuilder.ApplyFont;
            cellBuilderHandler += cellBuilder.ApplyParent;
            cellBuilderHandler += cellBuilder.ApplyLayoutElement;
            cellBuilderHandler += cellBuilder.ApplyBackgroundImage;

            var textCell = new TextCellDongerUI("", cellBuilderHandler);
            var cell = new CellUI(textCell);
            cell.Build();
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
        //TODO: Make it so that it has arrows that point in the direction of the arrows.
        private void GenerateMonthHeader(string monthName, Transform parent)
        {
            var row = CreateUIRow("Row", parent);

            //Generate the back button. 
            CreateUIButton("Back", row.transform, BackAMonth);
            
            BuildCell(monthName, parent);

            //This generates the forward month button. 
            CreateUIButton("Forward", row.transform, ForwardAMonth);
        }

        ///<summary>Create the header for days of the week. </summary>
        protected virtual void GenerateWeeksHeader()
        {
            var row = CreateUIRow("Row", _uiParentTransform);

            for (int i = 0; i < Calendar.DaysInWeek.Length; i++)
            {
                BuildCell(Calendar.DaysInWeek[i].ToString(), row.transform);
            }
        }

    }
}

