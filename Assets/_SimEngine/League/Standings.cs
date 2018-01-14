using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Donger.BuckeyeEngine
{
	[RequireComponent(typeof(League))]
	public class Standings : MonoBehaviour {
		protected List<Team> _teams = new List<Team>();
		protected List<Conference> _conferences = new List<Conference>();
		public List<Conference> Conferences{get{return _conferences;}}
		protected League _league;

		protected virtual void Start()
        {
            Initialization(); //Initializes the varitables.
            CreateConferences(); 
        }
		
		///<summary>Initialize the league variables</summary>
        private void Initialization()
        {
            _league = GetComponent<League>();
            _teams = _league.TeamsDatabase.Teams;
        }

		///<summary>This will create the conferences and the gameobjects at runtime</summary>
        private void CreateConferences()
        {
			//Creates the conferences from the text file.
            for (int i = 0; i < _teams.Count; i++)
            {
				//If the confernce already exists, then just add the team to the conference.
                if (_conferences.Exists(a => a.Name == _teams[i].Conference))
				{
					var conf = _conferences.Find(a => a.Name == _teams[i].Conference);
					conf.Teams.Add(_teams[i]);
				} 
				//Create a new conference, then add the team.
				else {
					var conference = new Conference(_teams[i].Conference);
					_conferences.Add(conference);
					conference.Teams.Add(_teams[i]);
				}
            }

			//Create Child GameObjects to Represent Conferences
			for (int i = 0; i < _conferences.Count; i++)
			{
				var conferenceGameObject = new GameObject(_conferences[i].Name);
				conferenceGameObject.transform.SetParent(this.gameObject.transform);
				conferenceGameObject.transform.localPosition = Vector3.zero;
			}
        }
    }
}

