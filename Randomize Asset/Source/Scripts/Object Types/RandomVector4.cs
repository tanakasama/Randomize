// RandomVector4.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomVector4
// Description:
// RandomObject for Vector4 data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomVector4 : RandomObjectBase
		{
			public static RandomVector4 CreateNew()
			{
				RandomVector4 rand = ScriptableObject.CreateInstance<RandomVector4>();
				rand.ValueType = GenericDataType.Vector4;
				return rand;
			}
			
			public new Vector4 Last()
			{
				return base.Last().GetVector4();
			}
			
			public new Vector4 Next()
			{
				return base.Last().GetVector4();
			}
		}
	}
}