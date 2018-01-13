using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.BuckeyeEngine{
	public interface ICoreEvent {
		string Name {get;set;}
		string ID{get;}
		int Year{get;set;}
		int Month{get;set;}
		int Day {get;set;}
		void AddComponentTo(GameObject gameObjectToAddTo);
	}
}

