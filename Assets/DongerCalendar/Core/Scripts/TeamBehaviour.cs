using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.BuckeyeEngine{
	public class TeamBehaviour : MonoBehaviour 
	{
		[SerializeField] protected Team _team;

		///<summary>Gets the team.!-- </summary>
		public Team Team{
			get{
				return _team;
			}
		}

		public void Setup(Team team)
		{
			_team = team;
		}
		
	}
}

