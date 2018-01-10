using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Donger.Tools;

namespace Donger.BuckeyeEngine
{
	[System.Serializable]
	public class CoreEvent {
		protected string _id;
		public string ID{get{return _id;}}
		public DateTime	Date;
		public int Day;
		public int Month;
		public int Year;
		public string Name;
		protected EventBehaviour _eventBehaviour;

		//Needs to stay as a virtual class.  An abstract class will not allow it to save the core event in the eventDatabase.
		public virtual void AddComponentTo(GameObject gameObjectToAddto){
			return;
		}

		public virtual void InitializeGameObject()
		{
			//Check if this has the right component on the gameobject.
			if (_eventBehaviour == null) Debug.LogError("The EventBehaviour is null.  You must use the AddComponentTo method first");	
		}
    }
}

