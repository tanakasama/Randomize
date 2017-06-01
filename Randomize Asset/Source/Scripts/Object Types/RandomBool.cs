// RandomBool.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomBool
// Description:
// RandomObject for boolean data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomBool : RandomObjectBase
		{
			public static RandomBool CreateNew()
			{
				RandomBool rand = ScriptableObject.CreateInstance<RandomBool>();
				rand.ValueType = GenericDataType.Bool;
				return rand;
			}
			
			public new bool Last()
			{
				return base.Last().GetBool();
			}
			
			public new bool Next()
			{
				return base.Last().GetBool();
			}
		}
	}
}