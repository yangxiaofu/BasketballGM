using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Donger.BuckeyeEngine{
	public class Simulator  {

		ISimulator _simulator;
		
		public Simulator (ISimulator simulator){
			_simulator = simulator;
		}

		///<summary>Simulates the game between two teams</summary>
		public virtual void Simulate()
		{
			_simulator.Simulate();
		}
	}
}

