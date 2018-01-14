using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.Tools{
	public abstract class FileReader : MonoBehaviour {
		[Tooltip("The name of the file including the extension.")]
		[SerializeField] protected string fileName = "TeamNames.csv";
		[Tooltip("The path of the file.  Do not include the filename.  Make sure to add the full path.")]
		[SerializeField] protected string path = "Assets/Resources/";
		///<summary>This converts the file data into a string.  </summary>
		///<returns>Returns an array of string</summary>

		public virtual string[] ReadData()
		{
			var thisPath = path + fileName;
			StreamReader reader = new StreamReader(thisPath);
			var fileDataString = reader.ReadToEnd();
			return fileDataString.Split("\n"[0]);
		}

		/* Example Used for reading each line. Teams is a list.
			for (int i = 0; i < lines.Length; i++)
			{
				string[] lineData = ((lines[i].Trim()).Split(","[0]));
				var team = new Team(lineData[0], lineData[1]);
				_teams.Add(team);
			}
		 */

		 public abstract void ConvertStringToList(string[] lines);

	}
}

