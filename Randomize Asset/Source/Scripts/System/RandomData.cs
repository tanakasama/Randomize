// RandomData.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomData<T>
// Description:
// Generic class that can provide the same functionality as
// RandomObjectBase derived types at runtime from any collection.
// Because RandomData is generic, instances of it cannot be saved
// the same way that instances of RandomObjectBase types can be,
// but this genericness allows RandomData to accommodate types
// that are not supported directly by the Randomize library.

using System;
using System.Collections.Generic;
using System.Linq;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomData<T>
		{
			private int LastReturnedIndex = -1;
			private Random RandomSeed = new Random();
			private T[] Values;
			private Playlist ValuePlaylist;

			public RandomBehavior Behavior;

			public RandomData()
			{
				Behavior = RandomBehavior.Random;
				Values = new T[0];
				ValuePlaylist = new Playlist(0);
			}

			public RandomData(IEnumerable<T> data)
			{
				Behavior = RandomBehavior.Random;
				Values = data.ToArray();
				ValuePlaylist = new Playlist(Values.Length);
			}

			public RandomData(IEnumerable<T> data, RandomBehavior behavior)
			{
				Behavior = behavior;
				Values = data.ToArray();
				ValuePlaylist = new Playlist(Values.Length);
			}

			private int GetPlaylist()
			{
				if(Values.Length < 2)
					return 0;

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

			public T Last()
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

			public T Next()
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

			public void SetValues(IEnumerable<T> data)
			{
				LastReturnedIndex = 0;
				Values = data.ToArray();
				ValuePlaylist = new Playlist(Values.Length);
			}
		}
	}
}