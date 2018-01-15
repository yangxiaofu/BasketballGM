using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Donger.Tools;

namespace Donger.BuckeyeEngine{
	[System.Serializable]
	public class Team{
		[SerializeField] private string _id;
		public string ID{get{return _id;}}
		public string CityName;
		public string NickName;
		public string Conference;
		[SerializeField] public Record Record;
		
		///<summary>Constructor for Team where team ID is automatically Generated using an automatic ID Generator</summary>
		public Team(string cityName, string nickName)
		{
			CityName = cityName;
			NickName = nickName;
			_id = UniqueID.Generate();
		}

		///<summary>Constructor where you can manually set the ID externally</summary>
		public Team(string manualID, string cityName, string nickName)
		{
			CityName = cityName;
			NickName = nickName;
			_id = manualID;
		}
	}
}
