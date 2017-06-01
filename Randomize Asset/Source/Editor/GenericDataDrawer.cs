// GenericDataDrawer.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.RandomizeEditor
// Class: GenericDataDrawer
// Description:
// PropertyDrawer for displaying GenericData objects in the inspector.
// The main reason for using a custom drawer for GenericData is to
// present the complex data structure to users as a single type value. 

using UnityEditor;
using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace RandomizeEditor
	{
		[CustomPropertyDrawer(typeof(GenericData))]
		public class GenericDataDrawer : PropertyDrawer
		{
			public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
			{
				EditorGUI.BeginProperty(position, label, property);
				
				position = EditorGUI.PrefixLabel(position, new GUIContent(string.Format("{0}", label.text)));

				int indentLevel = EditorGUI.indentLevel;
				EditorGUI.indentLevel = 0;
				{
					PropertyField(position, property);
				}
				EditorGUI.indentLevel = indentLevel;

				EditorGUI.EndProperty();
			}
			
			public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
			{
				string valueType = property.FindPropertyRelative("ValueType").enumNames[property.FindPropertyRelative("ValueType").enumValueIndex].ToUpper();
				
				if(valueType.Equals("RECT"))
					return base.GetPropertyHeight(property, label) * 2;
				else
					return base.GetPropertyHeight(property, label);
			}
			
			private void PropertyField(Rect position, SerializedProperty property)
			{
				SerializedProperty floA = property.FindPropertyRelative("FloA");
				SerializedProperty floB = property.FindPropertyRelative("FloB");
				SerializedProperty floC = property.FindPropertyRelative("FloC");
				SerializedProperty floD = property.FindPropertyRelative("FloD");
				SerializedProperty intA = property.FindPropertyRelative("IntA");
				SerializedProperty objectA = property.FindPropertyRelative("ObjectA");
				SerializedProperty stringA = property.FindPropertyRelative("StringA");
				string valueType = property.FindPropertyRelative("ValueType").enumNames[property.FindPropertyRelative("ValueType").enumValueIndex].ToUpper();

				if(valueType.Equals("AUDIOCLIP"))
				{
					objectA.objectReferenceValue = EditorGUI.ObjectField(position, objectA.objectReferenceValue, typeof(AudioClip), false) as AudioClip;
				}
				else if(valueType.Equals("BOOL"))
				{
					intA.intValue = (EditorGUI.Toggle(position, intA.intValue == 1) ? 1 : 0);
				}
				else if(valueType.Equals("COLOR"))
				{
					Color col = new Color(floA.floatValue, floB.floatValue, floC.floatValue, floD.floatValue);
					col = EditorGUI.ColorField(position, col);
					floA.floatValue = col.r;
					floB.floatValue = col.g;
					floC.floatValue = col.b;
					floD.floatValue = col.a;
				}
				else if(valueType.Equals("FLOAT"))
				{
					floA.floatValue = EditorGUI.FloatField(position, floA.floatValue);
				}
				else if(valueType.Equals("GAMEOBJECT"))
				{
					objectA.objectReferenceValue = EditorGUI.ObjectField(position, objectA.objectReferenceValue, typeof(GameObject), false) as GameObject;
				}
				else if(valueType.Equals("INT"))
				{
					intA.intValue = EditorGUI.IntField(position, intA.intValue);
				}
				else if(valueType.Equals("MATERIAL"))
				{
					objectA.objectReferenceValue = EditorGUI.ObjectField(position, objectA.objectReferenceValue, typeof(Material), false) as Material;
				}
				else if(valueType.Equals("OBJECT"))
				{
					objectA.objectReferenceValue = EditorGUI.ObjectField(position, objectA.objectReferenceValue, typeof(Object), false) as Object;
				}
				else if(valueType.Equals("RECT"))
				{
					Rect rect = new Rect(floA.floatValue, floB.floatValue, floC.floatValue, floD.floatValue);
					rect = EditorGUI.RectField(position, rect);
					floA.floatValue = rect.x;
					floB.floatValue = rect.y;
					floC.floatValue = rect.width;
					floD.floatValue = rect.height;
				}
				else if(valueType.Equals("STRING"))
				{
					stringA.stringValue = EditorGUI.TextField(position, stringA.stringValue);
				}
				else if(valueType.Equals("VECTOR2"))
				{
					Vector2 v = new Vector2(floA.floatValue, floB.floatValue);
					v = EditorGUI.Vector2Field(position, GUIContent.none, v);
					floA.floatValue = v.x;
					floB.floatValue = v.y;
				}
				else if(valueType.Equals("VECTOR3"))
				{
					Vector3 v = new Vector3(floA.floatValue, floB.floatValue, floC.floatValue);
					v = EditorGUI.Vector3Field(position, GUIContent.none, v);
					floA.floatValue = v.x;
					floB.floatValue = v.y;
					floC.floatValue = v.z;
				}
				else if(valueType.Equals("VECTOR4"))
				{
					Rect pos = new Rect(position.x, position.y - position.height, position.width, position.height);
					Vector4 v = new Vector4(floA.floatValue, floB.floatValue, floC.floatValue, floD.floatValue);
					v = EditorGUI.Vector4Field(pos, "", v);
					floA.floatValue = v.x;
					floB.floatValue = v.y;
					floC.floatValue = v.z;
					floD.floatValue = v.w;
				}
			}
		}
	}
}