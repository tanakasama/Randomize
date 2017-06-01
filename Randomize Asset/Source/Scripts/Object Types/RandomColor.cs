// RandomColor.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomColor
// Description:
// RandomObject for Color data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomColor : RandomObjectBase
		{
			public static RandomColor CreateNew()
			{
				RandomColor rand = ScriptableObject.CreateInstance<RandomColor>();
				rand.ValueType = GenericDataType.Color;
				return rand;
			}
			
			public new Color Last()
			{
				return base.Last().GetColor();
			}
			
			public new Color Next()
			{
				return base.Last().GetColor();
			}
		}
	}
}