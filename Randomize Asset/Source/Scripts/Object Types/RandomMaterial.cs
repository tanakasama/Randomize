// RandomMaterial.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomMaterial
// Description:
// RandomObject for Material data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomMaterial : RandomObjectBase
		{
			public static RandomMaterial CreateNew()
			{
				RandomMaterial rand = ScriptableObject.CreateInstance<RandomMaterial>();
				rand.ValueType = GenericDataType.Material;
				return rand;
			}
			
			public new Material Last()
			{
				return base.Last().GetMaterial();
			}
			
			public new Material Next()
			{
				return base.Last().GetMaterial();
			}
		}
	}
}