// RandomInt.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomInt
// Description:
// RandomObject for 32-bit integer data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomInt : RandomObjectBase
		{
			public static RandomInt CreateNew()
			{
				RandomInt rand = ScriptableObject.CreateInstance<RandomInt>();
				rand.ValueType = GenericDataType.Int;
				return rand;
			}

			public new int Last()
			{
				return base.Last().GetInt();
			}
			
			public new int Next()
			{
				return base.Last().GetInt();
			}
		}
	}
}