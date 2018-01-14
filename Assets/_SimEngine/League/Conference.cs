using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.BuckeyeEngine{
	[System.Serializable]
	public class Conference	{
		public string Name;
		public List<Team> Teams = new List<Team>();
		public Conference (string name){
			Name = name;
		}
	}
}
