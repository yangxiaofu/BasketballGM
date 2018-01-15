using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Donger.BuckeyeEngine{
    public class BasketballSimulator : ISimulator
    {
		private readonly Team _awayTeam;
		private readonly Team _homeTeam;
		private Results _results;
		public Results Results{get{return _results;}}

		//TODO: Add a way to determine if hte simulator has already simulated.

		public BasketballSimulator(Team awayTeam, Team homeTeam){
			_awayTeam = awayTeam;
			_homeTeam = homeTeam;

			_results = new Results();
		}
        public void Simulate()
        {
            Assert.IsNotNull(_awayTeam);
            Assert.IsNotNull(_homeTeam);

            //Randomize the winner for now. TEMPORARY.
            RandomizeWinner_TEMPORARY();

        }

		///<summary>This is a temporary method for now</summary>
        private void RandomizeWinner_TEMPORARY()
        {
            var r = UnityEngine.Random.Range(0, 2);

            if (r == 0)
            {
                _results.Winner = _awayTeam;
                _results.Loser = _homeTeam;
            }
            else
            {
                _results.Winner = _homeTeam;
                _results.Loser = _awayTeam;
            }
        }
    }

}
