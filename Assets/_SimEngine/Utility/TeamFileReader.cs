using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Donger.Tools;

namespace Donger.BuckeyeEngine{
	public class TeamFileReader : FileReader {
		[SerializeField] List<Team> _teams = new List<Team>();
		public List<Team> Teams{get{return _teams;}}
		public override void ConvertStringToList(string[] lines)
		{
			//Clear the teams before loading.
			_teams.Clear();

			//Find teams in the file and add into the game.
			for (int i = 0; i < lines.Length; i++)
			{
				string[] lineData = ((lines[i].Trim()).Split(","[0]));
				var team = new Team(lineData[0], lineData[1]);
				_teams.Add(team);
			}
		}
	}

}
