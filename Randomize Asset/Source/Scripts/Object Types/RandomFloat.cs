// RandomFloat.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomFloat
// Description:
// RandomObject for single precision floating point data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomFloat : RandomObjectBase
		{
			public static RandomFloat CreateNew()
			{
				RandomFloat rand = ScriptableObject.CreateInstance<RandomFloat>();
				rand.ValueType = GenericDataType.Float;
				return rand;
			}
			
			public new float Last()
			{
				return base.Last().GetFloat();
			}
			
			public new float Next()
			{
				return base.Last().GetFloat();
			}
		}
	}
}