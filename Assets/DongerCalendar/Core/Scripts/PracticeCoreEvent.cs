using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Donger.Tools;

namespace Donger.BuckeyeEngine{
    public class PracticeCoreEvent : CoreEvent, ICoreEvent
    {
		public string Name{ 
			get{ return _name; }
        	set{ _name = value;}
        }
        public string ID { get {return _id;} }
        public int Year { 
			get {return _year;}
			set{_year = value;}
		}
        public int Month { 
			get {return _month;} 
			set {_month = value;}
		}

        public int Day { 
			get {return _day;}
			set {_day = value;}
		}
		public PracticeCoreEvent(string name, DateTime date){
			this._name = name;
			this.Date = date;
			this._day = date.Day;
			this._month = date.Month;
			this._year = date.Year;

			//Generates a unique ID for the class;
			_id = UniqueID.Generate();
		}

        public void AddComponentTo(GameObject gameObjectToAddto)
        {
            _eventBehaviour = gameObjectToAddto.AddComponent<PracticeEventBehaviour>();
        }
    }
}

