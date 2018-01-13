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
		public DateTime	Date;
		protected int _day;
		protected int _month;
		protected int _year;
		protected string _name;
		protected EventBehaviour _eventBehaviour;
		public virtual void InitializeGameObject()
		{
			//Check if this has the right component on the gameobject.
			if (_eventBehaviour == null) Debug.LogError("The EventBehaviour is null.  You must use the AddComponentTo method first");	
		}
    }
}

