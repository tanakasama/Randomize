// Playlist.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.RandomizeInternal
// Class: Playlist
// Description:
// Data structure for storing an array of indicies that can be shuffled
// to create a playlist. The playlist does not store any data itself,
// but instead returns an index that is used by an outside collection
// for selecting an element to return.

using System.Collections.Generic;

namespace Zemanek
{
	namespace RandomizeInternal
	{
		public class Playlist
		{
			private int ElementCount;
			private int[] ElementOrder;
			private int LastReturnedIndex;
			
			public bool ShuffleOnEndReached;

			public int Size { get { return ElementCount; } }

			public Playlist()
			{
				ElementOrder = BuildArray(0);
			}
			
			public Playlist(int count)
			{
				ElementOrder = BuildArray(count);
				Shuffle();
			}
			
			private int[] BuildArray(int size)
			{
				int[] newIntArray = new int[size];
				for(int i = 0; i < newIntArray.Length; i++)
				{
					newIntArray[i] = i;
				}

				ElementCount = size;
				return newIntArray;
			}
			
			private void VerifyPlaylist()
			{
				if(ElementOrder == null || ElementOrder.Length != ElementCount)
				{
					ElementOrder = BuildArray(ElementCount);
					LastReturnedIndex = -1;
					Shuffle();
				}
			}
			
			public int Last()
			{
				VerifyPlaylist();
				
				if(LastReturnedIndex >= 0)
					return ElementOrder[LastReturnedIndex];
				else
					return ElementOrder[0];
			}
			
			public int Next()
			{
				VerifyPlaylist();

				if(LastReturnedIndex < ElementCount - 1)
				{
					LastReturnedIndex++;
					return ElementOrder[LastReturnedIndex];
				}
				else
				{
					if(ShuffleOnEndReached)
						Shuffle();
					
					LastReturnedIndex = 0;
					return ElementOrder[LastReturnedIndex];
				}
			}
			
			public void Shuffle()
			{
				System.Random shuffle = new System.Random();
				
				for(int i = 0; i < ElementOrder.Length; i++)
				{
					bool isUnique;
					
					do
					{
						ElementOrder[i] = shuffle.Next(0, ElementOrder.Length);
						
						isUnique = true;
						
						for(int j = 0; j < i; j++)
						{
							if(ElementOrder[i] == ElementOrder[j])
							{
								isUnique = false;
								break;
							}
						}
					}
					while(!isUnique);
				}
				
				LastReturnedIndex = -1;
			}
		}
	}
}