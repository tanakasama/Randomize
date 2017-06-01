// RandomVector3.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomVector3
// Description:
// RandomObject for Vector3 data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomVector3 : RandomObjectBase
		{
			public static RandomVector3 CreateNew()
			{
				RandomVector3 rand = ScriptableObject.CreateInstance<RandomVector3>();
				rand.ValueType = GenericDataType.Vector3;
				return rand;
			}
			
			public new Vector3 Last()
			{
				return base.Last().GetVector3();
			}
			
			public new Vector3 Next()
			{
				return base.Last().GetVector3();
			}
		}
	}
}