// RandomObjectBase.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.RandomizeInternal
// Class: RandomObjectBase
// Description:
// RandomObjectBase provides a way to create ScriptableObject instances
// that can contain a collection of data to be referenced randomly. This
// can be useful for creating a RandomAudioClip for a sound effect that
// can have multiple varients for example. An instance of the RandomAudioClip
// can be created in the project and used in multiple places like any other
// object. RandomObjectBase should never be created directly and is instead
// utilized by child classes such as RandomAudioClip.

using UnityEngine;
using System;
using Zemanek.Randomize;

namespace Zemanek
{
	namespace RandomizeInternal
	{
		public abstract class RandomObjectBase : ScriptableObject
		{
			private int LastReturnedIndex = -1;
			private System.Random RandomSeed = new System.Random();
			private Playlist ValuePlaylist;
			[SerializeField] protected GenericDataType ValueType;
			[SerializeField] protected GenericData[] Values;

			public RandomBehavior Behavior;

			protected GenericData Last()
			{
				if(Values == null || Values.Length == 0)
					throw new NullReferenceException("RandomData.Values is empty!");
				
				try
				{
					return Values[LastReturnedIndex];
				}
				catch(IndexOutOfRangeException)
				{
					LastReturnedIndex = 0;
					return Values[0];
				}
			}
			
			protected GenericData Next()
			{
				if(Values == null || Values.Length == 0)
					throw new NullReferenceException("RandomData.Values is empty!");
				
				int index = 0;
				switch(Behavior)
				{
				case RandomBehavior.Playlist:
					index = GetPlaylist();
					break;
				case RandomBehavior.Random:
					index = GetRandom();
					break;
				case RandomBehavior.RandomUnique:
					index = GetRandomUnique();
					break;
				case RandomBehavior.Sequential:
					index = GetSequential();
					break;
				case RandomBehavior.SequentialReverse:
					index = GetSequentialReverse();
					break;
				default:
					index = 0;
					break;
				}
				
				LastReturnedIndex = index;
				return Values[index];
			}

			private int GetPlaylist()
			{
				if(Values.Length < 2)
					return 0;

				if(ValuePlaylist == null || ValuePlaylist.Size != Values.Length)
					ValuePlaylist = new Playlist(Values.Length);

				return ValuePlaylist.Next();
			}
			
			private int GetRandom()
			{
				if(Values.Length < 2)
					return 0;
				
				return RandomSeed.Next(0, Values.Length);
			}
			
			private int GetRandomUnique()
			{
				if(Values.Length < 2)
					return 0;
				if(Values.Length == 2)
					return Math.Abs(LastReturnedIndex - 1);
				
				int index = 0;
				do index = RandomSeed.Next(0, Values.Length);
				while(index == LastReturnedIndex);
				
				return index;
			}
			
			private int GetSequential()
			{
				if(Values.Length < 2)
					return 0;
				if(Values.Length <= (LastReturnedIndex + 1))
					return 0;
				
				return LastReturnedIndex + 1;
			}
			
			public int GetSequentialReverse()
			{
				if(Values.Length < 2)
					return 0;
				if((LastReturnedIndex - 1) < 0)
					return Values.Length - 1;
				
				return LastReturnedIndex - 1;
			}
		}
	}
}