using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Donger.BuckeyeEngine{
	[CreateAssetMenu(menuName = "Create a Database/Teams Database")]
	public class TeamsDatabase : ScriptableObject{
		[SerializeField] public List<Team> Teams = new List<Team>();
	}

}
