using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Donger.Tools{
	[CustomEditor(typeof(FileReader), true)]
	public class FileReaderEditor : Editor {
		FileReader _reader;
		/// <summary>
		/// This function is called when the object becomes enabled and active.
		/// </summary>
		string[] _stringData;
		void OnEnable()
		{
			_reader = (FileReader)target;
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			DrawDefaultInspector();
			if (GUILayout.Button("Load File"))
			{
				_stringData = _reader.ReadData();
				_reader.ConvertStringToList(_stringData);
			}

			serializedObject.ApplyModifiedProperties();
		}
	}
}

