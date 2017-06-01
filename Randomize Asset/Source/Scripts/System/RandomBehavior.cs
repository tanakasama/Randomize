// RandomBehaviour.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomBehavior
// Description:
// RandomBehavior defines the pattern by which the RandomObject
// or RandomData instance will select a return value.
// Playlist : Using a playlist (Random with no repeats)
// Random : Completely randomly.
// RandomUnique : Randomly, but won't select the same value consecutively.
// Sequential : In the order they are stored.
// SequentialReverse : In the reverse order they are stored.

namespace Zemanek
{
	namespace Randomize
	{
		public enum RandomBehavior
		{
			Playlist,
			Random,
			RandomUnique,
			Sequential,
			SequentialReverse
		}
	}
}