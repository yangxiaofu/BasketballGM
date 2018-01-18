using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Should have things like: 
	//Make an interface for an editor window calednar vs the inspetor CALENDAR. These will have differnent bheaviours when you select the slot.
	
	//Goal is to automatically create game events in the seaon.
	Starting Point to ending point on the calendar.
		//Draw out the EDITOR GUI calendar. 
	Number of games in a season. 
	
 */
namespace Donger.BuckeyeEngine
{
	///</summary>The schedule Generator is responsible for generating a schedule of games.!--</summary>
	[RequireComponent(typeof(Calendar))]
	[ExecuteInEditMode]
	public class ScheduleGenerator : MonoBehaviour 
	{
		[SerializeField] public int StartYear;
		[SerializeField] public int StartMonth;
		[SerializeField] public int StartDay;
		[SerializeField] public int EndYear;
		[SerializeField] public int EndMonth;
		[SerializeField] public int EndDay;
		[SerializeField] GUISkin _skin;
		public GUISkin Skin{get{return _skin;}}
		protected Calendar _calendar;

		protected virtual void OnEnable()
		{
			if (!Application.isPlaying)
			{
				_calendar = GetComponent<Calendar>();
			}
		}

		protected virtual void Start()
		{
			if (Application.isPlaying)
			{
				_calendar = GetComponent<Calendar>();
				if (!_skin) Debug.LogError("There is no GUISkin to reference");
			}
		}
	}
}

