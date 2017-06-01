// RandomObject.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomObject
// Description:
// RandomObject for Object data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomObject : RandomObjectBase
		{
			public static RandomObject CreateNew()
			{
				RandomObject rand = ScriptableObject.CreateInstance<RandomObject>();
				rand.ValueType = GenericDataType.Object;
				return rand;
			}

			public new Object Last()
			{
				return base.Last().GetObject();
			}

			public new Object Next()
			{
				return base.Last().GetObject();
			}
		}
	}
}