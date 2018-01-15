using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Donger.Tools;

namespace Donger.BuckeyeEngine{
	public class TeamFileReader : FileReader {
		[SerializeField] TeamsDatabase _teamsDatabase;
		void Start()
		{
			Assert.IsNotNull(_teamsDatabase, "The TeamsDatabase must be referenced in " + this.gameObject.name);
		}

		public override void ConvertStringToList(string[] lines)
		{
			//Clear the teams before loading.
			_teamsDatabase.Teams.Clear();

			//Find teams in the file and add into the game.
			for (int i = 0; i < lines.Length; i++)
			{
				string[] lineData = ((lines[i].Trim()).Split(","[0]));

				var team = new Team(lineData[0], lineData[1], lineData[2]);

				team.Conference = lineData[3];
				_teamsDatabase.Teams.Add(team);
			}
		}
	}

}
