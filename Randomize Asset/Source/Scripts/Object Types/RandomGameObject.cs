// RandomGameObject.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomGameObject
// Description:
// RandomObject for GameObject data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomGameObject : RandomObjectBase
		{
			public static RandomGameObject CreateNew()
			{
				RandomGameObject rand = ScriptableObject.CreateInstance<RandomGameObject>();
				rand.ValueType = GenericDataType.GameObject;
				return rand;
			}
			
			public new GameObject Last()
			{
				return base.Last().GetGameObject();
			}
			
			public new GameObject Next()
			{
				return base.Last().GetGameObject();
			}
		}
	}
}