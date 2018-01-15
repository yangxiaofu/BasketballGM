using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.BuckeyeEngine{
	public interface ISimulator {
		Results Results{get;}
		void Simulate();
	}
}
