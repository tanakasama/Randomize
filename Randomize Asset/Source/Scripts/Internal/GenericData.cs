// GenericData.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.RandomizeInternal
// Class: GenericData
// Description:
// "Fake" generic data handling for RandomObjects. Unity REALLY does not like
// true generics and will ultimately not serialize anything that has a generic
// somewhere in the class (also generic object data is not serialized either).
// As a work around, I did my best to create a custom class that acts like
// generic data when used correctly while optimizing data storage (i.e. use one
// int variable for storing an int, or a bool with values 1 and 0). In the
// future, this class can be expanded to support RandomObjects of more types.

using UnityEngine;

namespace Zemanek
{
	namespace RandomizeInternal
	{
		[System.Serializable]
		public class GenericData
		{
			[SerializeField] private float FloA, FloB, FloC, FloD;
			[SerializeField] private int IntA;
			[SerializeField] private Object ObjectA = null;
			[SerializeField] private string StringA = null;
			
			[SerializeField] private GenericDataType ValueType = GenericDataType.Object;
			
			public GenericDataType CurrentType {get{return ValueType;}}
			public object CurrentValue;

			public GenericData()
			{
				ValueType = GenericDataType.AudioClip;
			}

			public GenericData(GenericDataType type)
			{
				ValueType = type;
			}
			
			private string CastExceptionMessage(object to, object from, bool setFlag)
			{
				if(setFlag)
					return string.Format("Cannot set {0}, GenericData currently storing {1}", to, from);
				else
					return string.Format("Cannot retrieve {0}, GenericData currently storing {1}", to, from);
			}
			
			public bool CompareType(System.Type type)
			{
				switch(ValueType)
				{
				case GenericDataType.AudioClip:
					return type == typeof(AudioClip);
				case GenericDataType.Bool:
					return type == typeof(bool);
				case GenericDataType.Color:
					return type == typeof(Color);
				case GenericDataType.Float:
					return type == typeof(float);
				case GenericDataType.GameObject:
					return type == typeof(GameObject);
				case GenericDataType.Int:
					return type == typeof(int);
				case GenericDataType.Material:
					return type == typeof(Material);
				case GenericDataType.Object:
					return type == typeof(Object);
				case GenericDataType.Rect:
					return type == typeof(Rect);
				case GenericDataType.String:
					return type == typeof(string);
				case GenericDataType.Vector2:
					return type == typeof(Vector2);
				case GenericDataType.Vector3:
					return type == typeof(Vector3);
				case GenericDataType.Vector4:
					return type == typeof(Vector4);
				default:
					return false;
				}
			}
			
			public AudioClip GetAudioClip()
			{
				if(ValueType == GenericDataType.AudioClip)
					return (AudioClip)ObjectA;
				else
					throw new System.InvalidCastException(CastExceptionMessage("AudioClip", ValueType, false));
			}
			
			public bool GetBool()
			{
				if(ValueType == GenericDataType.Bool)
					return IntA == 1;
				else
					throw new System.InvalidCastException(CastExceptionMessage("Bool", ValueType, false));
			}
			
			public Color GetColor()
			{
				if(ValueType == GenericDataType.Color)
					return new Color(FloA, FloB, FloC, FloD);
				else
					throw new System.InvalidCastException(CastExceptionMessage("Color", ValueType, false));
			}
			
			public float GetFloat()
			{
				if(ValueType == GenericDataType.Float)
					return FloA;
				else
					throw new System.InvalidCastException(CastExceptionMessage("Float", ValueType, false));
			}
			
			public GameObject GetGameObject()
			{
				if(ValueType == GenericDataType.GameObject)
					return (GameObject)ObjectA;
				else
					throw new System.InvalidCastException(CastExceptionMessage("GameObject", ValueType, false));
			}
			
			public int GetInt()
			{
				if(ValueType == GenericDataType.Int)
					return IntA;
				else
					throw new System.InvalidCastException(CastExceptionMessage("Int", ValueType, false));
			}
			
			public Material GetMaterial()
			{
				if(ValueType == GenericDataType.Material)
					return (Material)ObjectA;
				else
					throw new System.InvalidCastException(CastExceptionMessage("Material", ValueType, false));
			}
			
			public Object GetObject()
			{
				if(ValueType == GenericDataType.Object)
					return (Object)ObjectA;
				else
					throw new System.InvalidCastException(CastExceptionMessage("Object", ValueType, false));
			}
			
			public Rect GetRect()
			{
				if(ValueType == GenericDataType.Rect)
					return new Rect(FloA, FloB, FloC, FloD);
				else
					throw new System.InvalidCastException(CastExceptionMessage("Rect", ValueType, false));
			}
			
			public string GetString()
			{
				if(ValueType == GenericDataType.Rect)
					return StringA;
				else
					throw new System.InvalidCastException(CastExceptionMessage("String", ValueType, false));
			}
			
			public Vector2 GetVector2()
			{
				if(ValueType == GenericDataType.Vector2)
					return new Vector2(FloA, FloB);
				else
					throw new System.InvalidCastException(CastExceptionMessage("Vector2", ValueType, false));
			}
			
			public Vector3 GetVector3()
			{
				if(ValueType == GenericDataType.Vector3)
					return new Vector3(FloA, FloB, FloC);
				else
					throw new System.InvalidCastException(CastExceptionMessage("Vector3", ValueType, false));
			}
			
			public Vector4 GetVector4()
			{
				if(ValueType == GenericDataType.Vector4)
					return new Vector4(FloA, FloB, FloC, FloD);
				else
					throw new System.InvalidCastException(CastExceptionMessage("Vector4", ValueType, false));
			}
			
			public void Reset()
			{
				FloA = 0;
				FloB = 0;
				FloC = 0;
				FloD = 0;
				IntA = 0;
				ObjectA = null;
				StringA = null;
			}
			
			public void SetAudioClip(AudioClip value, bool overrideType)
			{
				if(ValueType == GenericDataType.AudioClip || overrideType)
				{
					ObjectA = value;
					ValueType = GenericDataType.AudioClip;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("AudioClip", ValueType, true));
				}
			}
			
			public void SetBool(bool value, bool overrideType)
			{
				if(ValueType == GenericDataType.Bool || overrideType)
				{
					IntA = (value ? 1 : 0);
					ValueType = GenericDataType.Bool;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("Bool", ValueType, true));
				}
			}
			
			public void SetColor(Color value, bool overrideType)
			{
				if(ValueType == GenericDataType.Color || overrideType)
				{
					FloA = value.r;
					FloB = value.g;
					FloC = value.b;
					FloD = value.a;
					ValueType = GenericDataType.Color;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("Color", ValueType, true));
				}
			}
			
			public void SetFloat(float value, bool overrideType)
			{
				if(ValueType == GenericDataType.Color || overrideType)
				{
					FloA = value;
					ValueType = GenericDataType.Float;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("Float", ValueType, true));
				}
			}
			
			public void SetGameObject(GameObject value, bool overrideType)
			{
				if(ValueType == GenericDataType.GameObject || overrideType)
				{
					ObjectA = value;
					ValueType = GenericDataType.GameObject;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("GameObject", ValueType, true));
				}
			}
			
			public void SetInt(int value, bool overrideType)
			{
				if(ValueType == GenericDataType.Int || overrideType)
				{
					IntA = value;
					ValueType = GenericDataType.Int;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("Int", ValueType, true));
				}
			}
			
			public void SetMaterial(Material value, bool overrideType)
			{
				if(ValueType == GenericDataType.Material || overrideType)
				{
					ObjectA = value;
					ValueType = GenericDataType.Material;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("Material", ValueType, true));
				}
			}
			
			public void SetObject(Object value, bool overrideType)
			{
				if(ValueType == GenericDataType.Object || overrideType)
				{
					ObjectA = value;
					ValueType = GenericDataType.Object;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("Object", ValueType, true));
				}
			}
			
			public void SetRect(Rect value, bool overrideType)
			{
				if(ValueType == GenericDataType.Rect || overrideType)
				{
					FloA = value.x;
					FloB = value.y;
					FloC = value.width;
					FloD = value.height;
					ValueType = GenericDataType.Rect;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("Rect", ValueType, true));
				}
			}
			
			public void SetString(string value, bool overrideType)
			{
				if(ValueType == GenericDataType.String || overrideType)
				{
					StringA = value;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("String", ValueType, true));
				}
			}
			
			public void SetVector2(Vector2 value, bool overrideType)
			{
				if(ValueType == GenericDataType.Vector2 || overrideType)
				{
					FloA = value.x;
					FloB = value.y;
					ValueType = GenericDataType.Vector2;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("Vector2", ValueType, true));
				}
			}
			
			public void SetVector3(Vector3 value, bool overrideType)
			{
				if(ValueType == GenericDataType.Vector3 || overrideType)
				{
					FloA = value.x;
					FloB = value.y;
					FloC = value.z;
					ValueType = GenericDataType.Vector3;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("Vector3", ValueType, true));
				}
			}
			
			public void SetVector4(Vector4 value, bool overrideType)
			{
				if(ValueType == GenericDataType.Vector4 || overrideType)
				{
					FloA = value.x;
					FloB = value.y;
					FloC = value.z;
					FloD = value.w;
					ValueType = GenericDataType.Vector4;
				}
				else
				{
					throw new System.InvalidCastException(CastExceptionMessage("Vector4", ValueType, true));
				}
			}
		}
	}
}