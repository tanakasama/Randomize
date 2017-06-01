// RandomRect.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomRect
// Description:
// RandomObject for Rect data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomRect : RandomObjectBase
		{
			public static RandomRect CreateNew()
			{
				RandomRect rand = ScriptableObject.CreateInstance<RandomRect>();
				rand.ValueType = GenericDataType.Rect;
				return rand;
			}
			
			public new Rect Last()
			{
				return base.Last().GetRect();
			}
			
			public new Rect Next()
			{
				return base.Last().GetRect();
			}
		}
	}
}