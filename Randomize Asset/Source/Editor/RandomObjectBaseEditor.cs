// RandomObjectBaseEditor.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.RandomizeEditor
// Class: RandomObjectBaseEditor
// Description:
// Custom editor for any RandomObjectBase derived types.

using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace RandomizeEditor
	{
		[CustomEditor(typeof(RandomObjectBase), true)]
		public class RandomObjectBaseEditor : Editor
		{
			private void Behavior(SerializedProperty behavior)
			{
				EditorGUILayout.PropertyField(behavior);

				string behaviorString = behavior.enumNames[behavior.enumValueIndex].ToUpper();
				string behaviorDescription = "";
				if(behaviorString.Equals("PLAYLIST"))
					behaviorDescription = "Returns values randomly in such a way where each value is returned once.";
				if(behaviorString.Equals("RANDOM"))
					behaviorDescription = "Returns each value completely randomly.";
				if(behaviorString.Equals("RANDOMUNIQUE"))
					behaviorDescription = "Returns each value randomly without returning the same value twice in a row.";
				if(behaviorString.Equals("SEQUENTIAL"))
					behaviorDescription = "Returns each value in the order they appear in.";
				if(behaviorString.Equals("SEQUENTIALREVERSE"))
					behaviorDescription = "Returns each value in the reverse order they appear in.";

				EditorGUILayout.BeginHorizontal();
				{
					EditorGUILayout.PrefixLabel(" ");
					EditorGUILayout.HelpBox(behaviorDescription, MessageType.None);
				}
				EditorGUILayout.EndHorizontal();
			}

			private void ValuesArray(SerializedProperty dataArray, SerializedProperty dataType)
			{
				dataArray.arraySize = EditorGUILayout.IntField("Value Count", dataArray.arraySize);

				EditorGUI.indentLevel++;
				for(int i = 0; i < dataArray.arraySize; i++)
				{
					EditorGUILayout.BeginHorizontal();
					{
						SerializedProperty dataEntry = dataArray.GetArrayElementAtIndex(i);
						dataEntry.FindPropertyRelative("ValueType").intValue = dataType.intValue;

						EditorGUILayout.PropertyField(dataEntry);

						EditorGUI.BeginDisabledGroup(i == 0);
						if(GUILayout.Button("▲", EditorStyles.miniButtonLeft, GUILayout.Width(22)))
						{
							dataArray.MoveArrayElement(i, i - 1);
						}
						EditorGUI.EndDisabledGroup();
						EditorGUI.BeginDisabledGroup(i == dataArray.arraySize - 1);
						if(GUILayout.Button("▼", EditorStyles.miniButtonMid, GUILayout.Width(22)))
						{
							dataArray.MoveArrayElement(i, i + 1);
						}
						EditorGUI.EndDisabledGroup();
						if(GUILayout.Button("X", EditorStyles.miniButtonRight, GUILayout.Width(22)))
							dataArray.DeleteArrayElementAtIndex(i);
					}
					EditorGUILayout.EndHorizontal();
				}
				EditorGUI.indentLevel--;
			}

			private void ValuesType(SerializedProperty dataType)
			{
				EditorGUILayout.LabelField("Data Type", dataType.enumNames[dataType.enumValueIndex]);
			}

			public override void OnInspectorGUI ()
			{
				serializedObject.Update();

				ValuesType(serializedObject.FindProperty("ValueType"));
				Behavior(serializedObject.FindProperty("Behavior"));
				EditorGUILayout.Space();
				ValuesArray(serializedObject.FindProperty("Values"), serializedObject.FindProperty("ValueType"));
				
				serializedObject.ApplyModifiedProperties();
			}
		}
	}
}