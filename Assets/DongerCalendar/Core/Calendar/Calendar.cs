using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace Donger.BuckeyeEngine{
	//Track the current date in the game (done) 
	//Track all days in the calendar.  Needs to store events in a certain date. 
	//Move to a specific date. 
	[ExecuteInEditMode]
	public class Calendar : MonoBehaviour
	{
		public Date SelectedDate;
		[HideInInspector] public int StartingYear = 2018;
		[HideInInspector] public int StartingMonth = 1;
		[HideInInspector] public int StartingDay = 1;

		///<summary>All days of the week written out</summary>
		public static string[] DaysInWeek = {"Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat"};
		
		///<summary>Months in the Year</summary>
		public static string[] Months = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec"};

		public delegate void Updated(DateTime date);
		public event Updated OnUpdated;

		protected EventManager _eventManager;
		public EventManager EventManager{get{return _eventManager;}}


		protected virtual void OnEnable()
		{
			if (!Application.isPlaying)
			{
				_eventManager = GetComponent<EventManager>();
			}
		}

		protected virtual void Awake()
		{
			if (Application.isPlaying)
			{
				SelectedDate = new Date(StartingYear, StartingMonth, StartingDay);
			}
		}

		protected virtual void Start()
		{
			if (Application.isPlaying)
			{
				_eventManager = GetComponent<EventManager>();
			}
		}
		
		public string HelpBox()
		{
			return "The Calendar is responsible for handling the dates in the simluation.";
		}
		
		///<summary>Updates the calendar values</summary>
		public virtual void UpdateCalendar(int year, int month, int day)
        {
            SelectedDate.Year = year;
            SelectedDate.Month = month;
            SelectedDate.Day = day;

            NotifyObservers(year, month, day);
        }

		///<summary>Resets the calendar to the default values</summary>
        public virtual void ResetToDefault()
        {
			UpdateCalendar(StartingYear, StartingMonth, StartingDay);
        }

		protected virtual void NotifyObservers(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            if (OnUpdated != null) OnUpdated(date);
        }

		///<summary>Returns the integer representation for the day of the week.  Returns the index related to the day. Return 0 for Sunday and 6 for Saturday.</summary>
		public static int GetDayOfWeekIndex(DayOfWeek dayOfWeek)
		{
			if (dayOfWeek == DayOfWeek.Sunday){
				return 0;
			} else if (dayOfWeek == DayOfWeek.Monday){
				return 1; 
			} else if (dayOfWeek == DayOfWeek.Tuesday){
				return 2;
			} else if (dayOfWeek == DayOfWeek.Wednesday){
				return 3;	
			} else if (dayOfWeek == DayOfWeek.Thursday){
				return 4;
			} else if (dayOfWeek == DayOfWeek.Friday){
				return 5;
			} else {
				return 6;
			}
		}

		///<summary>This advances the calendar by one month</summary>
		public void ForwardMonth()
		{
			SelectedDate.ForwardMonth();
		}

		///<summary>This move the months back one</summary>
		public void BackMonth()
		{
			SelectedDate.BackMonth();
		}
    }
}

