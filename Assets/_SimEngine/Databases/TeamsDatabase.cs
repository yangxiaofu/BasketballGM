using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.BuckeyeEngine{
	[CreateAssetMenu(menuName = "Create a Database/Teams Database")]
	public class TeamsDatabase : ScriptableObject{
		[SerializeField] public List<Team> Teams = new List<Team>();

		///<summary>Gets the team in the team database.  </summary>
		///<returns>Returns the team.!--</summary>
		public Team GetTeam(string teamID)
		{
			return Teams.Find(a => a.ID == teamID);
		}

		///<summary>This will reset the team database.  </summary>
		public void Reset()
		{
			Teams.Clear();
		}
	}

}
