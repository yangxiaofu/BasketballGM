using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Donger.BuckeyeEngine{
	public class GameManager : MonoBehaviour {
		[SerializeField] public TeamsDatabase TeamsDatabase;

		void Start(){
			Assert.IsNotNull(TeamsDatabase, "You must have the teams database referenced in " + this.gameObject.name);
		}
	}
}

