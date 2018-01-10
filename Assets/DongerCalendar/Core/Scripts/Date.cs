using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.BuckeyeEngine{
	[System.Serializable]
	public class Date{

		[Range(2000, 3000)]
		[SerializeField] int _year;
		public int Year{
			get{return _year;}
			set{_year = value;}
		}

		[Range(1, 12)]
		[SerializeField] int _month;
		public int Month {
			get{return _month;}
			set{_month = value;}
		}
		[Range(1, 30)]
		[SerializeField] int _day;
		public int Day{
			get {return _day;}
			set{_day = value;}
		}

		DateTime _date;
		public DateTime DateTime{
			get{return _date;}
			set{_date = value;}
		}

		public DayOfWeek DayOfWeek{
			get{
				var dateTime = new DateTime(_year, _month, _day);
				return dateTime.DayOfWeek;
			}
		}
		
	#region Constructors
		public Date(int year, int month, int day)
		{
			_year = year;
			_month = month;
			_day = day;

			//This will throw an error if the date is invalid. 
			_date = new DateTime(year, month, day);
		}

		public Date(DateTime dateTime){
			_date = dateTime;
		}

	#endregion

	#region Public Methods

		///<summary>Forwards the month</summary>
		public void ForwardMonth(){
			_month += 1;

			if (_month > 12){
				_month = 1;
				_year += 1;
			}
		}

		///<summary>Rewinds the month</summary>
		public void BackMonth()
		{
			_month -= 1;

			if (_month < 1)
			{
				_month = 12;
				_year -= 1;
			}
		}

	#endregion
	}
}
