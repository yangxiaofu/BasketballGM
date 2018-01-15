using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Donger.BuckeyeEngine{
	public class League : MonoBehaviour {
		private static League _instance;
		public static League Instance()
		{
			if(!_instance)
			{
				_instance = FindObjectOfType<League>();
				if (!_instance) Debug.LogError("You must have a league referenced in the gamescene.  Try dragging in the league Prefab into the game scene to fix this.");
			}

			return _instance;
		}

		[SerializeField] public TeamsDatabase TeamsDatabase;

		void Start()
		{
			Assert.IsNotNull(TeamsDatabase);
		}
	}
}

