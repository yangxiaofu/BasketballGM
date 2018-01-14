using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.BuckeyeEngine{
	public class TeamGenerator : MonoBehaviour {

		[Tooltip("The number of teams to Generate")]
		[SerializeField] int _numberOfTeams = 32;
		[SerializeField] List<Team> _teams = new List<Team>();

		///<summary>Generate X Number of teams</summary>
		public void GenerateTeams()
		{
			for (int i = 0; i < _numberOfTeams; i++)
			{
				var team = new Team("Fake", "City");
				_teams.Add(team);
			}
		}

		///<summary>Clear List</summary>
		public void ClearTeams(){
			_teams.Clear();
		}
	}
}

