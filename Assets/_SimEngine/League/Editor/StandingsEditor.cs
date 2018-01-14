using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.BuckeyeEngine{
	[CustomEditor(typeof(Standings))]
	public class StandingsEditor : Editor {

		Standings _standings;
		/// <summary>
		/// This function is called when the object becomes enabled and active.
		/// </summary>
		void OnEnable()
		{
			_standings = (Standings)target;
		}

		public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("If there are any chances to the team configurations, then you need to refresh the team in the TeamFileReader ", MessageType.Info);
            EditorGUILayout.Space();

            DrawDefaultInspector();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Standings", EditorStyles.boldLabel);
            EditorGUILayout.Space();
			
			//If the application is in PlayMode
			if (Application.isPlaying)
			{
				//Draw East Team Standings
				DrawConferenceStandings("East");
				EditorGUILayout.Space();
				//Draw West Team Standings
				DrawConferenceStandings("West");
			} 
			//otherwise, just let the user know that it only compiles at run-time.
			else {
				EditorGUILayout.HelpBox("Draws Standings at run-time", MessageType.Info);
			}
        }

        private void DrawConferenceStandings(string conferenceName)
        {
			float width = 50f;
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(conferenceName, EditorStyles.boldLabel, GUILayout.Width(200f));
			EditorGUILayout.LabelField("Wins", GUILayout.Width(width));
			EditorGUILayout.LabelField("Losses", GUILayout.Width(width));
			EditorGUILayout.LabelField("Ties", GUILayout.Width(width));
			EditorGUILayout.EndHorizontal();

            var conference = _standings.Conferences.Find(a => a.Name == conferenceName); //TODO: Make this more automatic
            for (int i = 0; i < conference.Teams.Count; i++)
            {
				EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(conference.Teams[i].CityName + " " + conference.Teams[i].NickName, GUILayout.Width(200f));
				EditorGUILayout.LabelField(conference.Teams[i].Record.Wins.ToString(), GUILayout.Width(width));
				EditorGUILayout.LabelField(conference.Teams[i].Record.Losses.ToString(), GUILayout.Width(width));
				EditorGUILayout.LabelField(conference.Teams[i].Record.Ties.ToString(), GUILayout.Width(width));
				EditorGUILayout.EndHorizontal();

            }
        }
    }
}

