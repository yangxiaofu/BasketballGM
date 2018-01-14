using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Donger.Tools;

namespace Donger.BuckeyeEngine{
	[System.Serializable]
	public class Team{
		private readonly string _id;
		public string ID{get{return _id;}}
		public string CityName;
		public string NickName;
		public string Conference;
		public Team(string cityName, string nickName)
		{
			CityName = cityName;
			NickName = nickName;
			_id = UniqueID.Generate();
		}
	}
}
