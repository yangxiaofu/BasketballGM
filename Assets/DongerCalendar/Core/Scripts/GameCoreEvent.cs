using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Donger.Tools;

namespace Donger.BuckeyeEngine{
	
	[System.Serializable]
    public class GameCoreEvent : CoreEvent, ICoreEvent
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

		protected string _homeTeamID;
		protected string _awayTeamID;

		public GameCoreEvent(string name, DateTime date, string homeTeamID, string awayTeamID){
			this._name = name;
			this.Date = date;
			this._day = date.Day;
			this._month = date.Month;
			this._year = date.Year;

			//set up the teams playing against each other.
			_homeTeamID = homeTeamID;
			_awayTeamID = awayTeamID;

			//Generates a unique ID for the class;
			_id = UniqueID.Generate();
		}

        public void AddComponentTo(GameObject gameObjectTotAddTo)
        {
            _eventBehaviour = gameObjectTotAddTo.AddComponent<GameEventBehaviour>();
			(_eventBehaviour as GameEventBehaviour).Setup(_awayTeamID, _homeTeamID);
        }
    }

}
