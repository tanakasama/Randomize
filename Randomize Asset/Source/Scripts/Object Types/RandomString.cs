// RandomString.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.Randomize
// Class: RandomString
// Description:
// RandomObject for String data.

using UnityEngine;
using Zemanek.RandomizeInternal;

namespace Zemanek
{
	namespace Randomize
	{
		public class RandomString : RandomObjectBase
		{
			public static RandomString CreateNew()
			{
				RandomString rand = ScriptableObject.CreateInstance<RandomString>();
				rand.ValueType = GenericDataType.String;
				return rand;
			}
			
			public new string Last()
			{
				return base.Last().GetString();
			}
			
			public new string Next()
			{
				return base.Last().GetString();
			}
		}
	}
}