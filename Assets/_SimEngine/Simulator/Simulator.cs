using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Donger.BuckeyeEngine{
	public class Simulator  {

		private readonly ISimulator _simulator;
		public Results Results{ get{return _simulator.Results;} }
		
		public Simulator (ISimulator simulator)
		{
			_simulator = simulator;
		}

		///<summary>Simulates the game between two teams</summary>
		public virtual void Simulate()
		{
			_simulator.Simulate();
		}
	}
}

