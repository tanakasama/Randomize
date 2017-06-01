// RandomAudioClip.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomAudioClip
// Description:
// RandomObject for AudioClip data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomAudioClip : RandomObjectBase
		{
			public static RandomAudioClip CreateNew()
			{
				RandomAudioClip rand = ScriptableObject.CreateInstance<RandomAudioClip>();
				rand.ValueType = GenericDataType.AudioClip;
				return rand;
			}
			
			public new AudioClip Last()
			{
				return base.Last().GetAudioClip();
			}
			
			public new AudioClip Next()
			{
				return base.Last().GetAudioClip();
			}
		}
	}
}