// RandomVector2.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomVector2
// Description:
// RandomObject for Vector2 data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomVector2 : RandomObjectBase
		{
			public static RandomVector2 CreateNew()
			{
				RandomVector2 rand = ScriptableObject.CreateInstance<RandomVector2>();
				rand.ValueType = GenericDataType.Vector2;
				return rand;
			}
			
			public new Vector2 Last()
			{
				return base.Last().GetVector2();
			}
			
			public new Vector2 Next()
			{
				return base.Last().GetVector2();
			}
		}
	}
}