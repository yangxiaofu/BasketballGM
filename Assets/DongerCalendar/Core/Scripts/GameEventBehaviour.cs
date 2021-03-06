﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.BuckeyeEngine{
	public class GameEventBehaviour : EventBehaviour{

        [SerializeField] protected string _awayTeamID;
        [SerializeField] protected string _homeTeamID;
        protected Team _awayTeam;
        protected Team _homeTeam;
        protected Simulator _simulator;

        ///<summary>will set up the gameObjects in the scene for these teams.  Sets up the simulator as well.  </summary>
        public virtual void Setup(string awayTeamID, string homeTeamID)
        {
            _awayTeamID = awayTeamID;
            _homeTeamID = homeTeamID;

            //Set up the game objects for the awya team and the home team.
            _awayTeam = SetupTeam(_awayTeamID);
            _homeTeam = SetupTeam(_homeTeamID);

            //Set up the simulator
            _simulator = new Simulator(new BasketballSimulator(_awayTeam, _homeTeam));
        }

        ///<summary>Will set up the teams in the game scene.  </summary>
        ///<returns>Returns the created team gameObject. </returns>
        protected virtual Team SetupTeam(string teamID)
        {
            //Create the gameObject for the team.
            var team = League.Instance().TeamsDatabase.GetTeam(teamID);
            var teamGameObject = new GameObject(team.CityName);
            teamGameObject.transform.SetParent(this.transform);
            teamGameObject.transform.localPosition = Vector3.zero;

            //Adds the team behaviour
            var teamBehaviour = teamGameObject.AddComponent<TeamBehaviour>();
            teamBehaviour.Setup(team);

            return team;
        }

        ///<summary>Simulates the simulator.  </summary>
        public override void Simulate()
        {
            _simulator.Simulate();            

            //update team records
            UpdateTeamRecords();
        }

        ///<summary>Update the records for each team.</summary>
        protected virtual void UpdateTeamRecords()
        {
            var results = _simulator.Results;
            //If the home team is the winner.
            if (results.Winner == _homeTeam){
                _homeTeam.Record.Wins += 1;
                _awayTeam.Record.Losses += 1;
            }
            //otherwise, the home team is the loser.
            else {
                _homeTeam.Record.Losses += 1;
                _awayTeam.Record.Wins += 1;
            }
        }
    }
}

