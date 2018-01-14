using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Donger.BuckeyeEngine{
	public class League : MonoBehaviour {

		[SerializeField] public TeamsDatabase TeamsDatabase;

		void Start(){
			Assert.IsNotNull(TeamsDatabase);
		}
	}
}

