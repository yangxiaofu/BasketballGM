using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Donger.BuckeyeEngine{
    public class BasketballSimulator : ISimulator
    {
		private readonly Team _awayTeam;
		private readonly Team _homeTeam;

		public BasketballSimulator(Team awayTeam, Team homeTeam){
			_awayTeam = awayTeam;
			_homeTeam = homeTeam;
		}
        public void Simulate()
        {
			//TODO: Create Results script that returns the results of the game.
			Assert.IsNotNull(_awayTeam);
			Assert.IsNotNull(_homeTeam);
			Debug.Log("Simulating");
        }
    }

}
