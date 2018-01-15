using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Donger.BuckeyeEngine{
	public class Simulator  {
		private readonly Team _awayTeam;
		private readonly Team _hometeam;
		public Simulator (Team awayTeam, Team homeTeam){
			_awayTeam = awayTeam;
			_hometeam = homeTeam;
		}

		///<summary>Simulates the game between two teams</summary>
		public virtual void Simulate()
		{
			//TODO: Create Results script that returns the results of the game.
			Assert.IsNotNull(_awayTeam);
			Assert.IsNotNull(_hometeam);

			Debug.Log("Simulating the results between two teams");
		}
	}
}

