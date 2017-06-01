// AssetCreationMenus.cs Copyright (C) 2017 Chase Zemanek

// Author: Chase Zemanek
// Namespace: Zemanek.RandomizeEditor
// Class: AssetCreationMenus
// Description:
// Static class that contains methods for creating new
// RandomObject instances through the Asset/Create menu.

using UnityEditor;
using System.IO;
using Zemanek.Randomize;

namespace Zemanek
{
	namespace RandomizeEditor
	{
		public static class AssetCreationMenus
		{
			private static string GetCurrentFolder()
			{
				string folder = AssetDatabase.GetAssetPath(Selection.activeInstanceID);

				if(folder == "")
					folder = "Assets";
				else if(Path.GetExtension(folder) != "")
					folder = folder.Replace(Path.GetFileName(folder), "");

				return folder;
			}

			private static string GetAssetPath(string typeName)
			{
				return AssetDatabase.GenerateUniqueAssetPath(string.Format("{0}/New Random {1}.asset", GetCurrentFolder(), typeName));
			}

			[MenuItem("Assets/Create/Randomize/Audio Clip", false, 0)]
			public static void CreateRandomAudioClip()
			{
				RandomAudioClip rand = RandomAudioClip.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Audio Clip"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Bool", false, 100)]
			public static void CreateRandomBool()
			{
				RandomBool rand = RandomBool.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Bool"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Color", false, 0)]
			public static void CreateRandomColor()
			{
				RandomColor rand = RandomColor.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Color"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Float", false, 100)]
			public static void CreateRandomFloat()
			{
				RandomFloat rand = RandomFloat.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Float"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Game Object", false, 0)]
			public static void CreateRandomGameObject()
			{
				RandomGameObject rand = RandomGameObject.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Game Object"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Int", false, 100)]
			public static void CreateRandomInt()
			{
				RandomInt rand = RandomInt.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Int"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Material", false, 0)]
			public static void CreateRandomMaterial()
			{
				RandomMaterial rand = RandomMaterial.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Material"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Object", false, 0)]
			public static void CreateRandomObject()
			{
				RandomObject rand = RandomObject.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Object"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Rect", false, 100)]
			public static void CreateRandomRect()
			{
				RandomRect rand = RandomRect.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Rect"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}
			
			[MenuItem("Assets/Create/Randomize/String", false, 100)]
			public static void CreateRandomString()
			{
				RandomString rand = RandomString.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("String"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Vector2", false, 100)]
			public static void CreateRandomVector2()
			{
				RandomVector2 rand = RandomVector2.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Vector2"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Vector3", false, 100)]
			public static void CreateRandomVector3()
			{
				RandomVector3 rand = RandomVector3.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Vector3"));
				Selection.activeInstanceID = rand.GetInstanceID();
			}

			[MenuItem("Assets/Create/Randomize/Vector4", false, 100)]
			public static void CreateRandomVector4()
			{
				RandomVector4 rand = RandomVector4.CreateNew();
				AssetDatabase.CreateAsset(rand, GetAssetPath("Vector4"));
				//Selection.activeInstanceID = rand.GetInstanceID();
			}
		}
	}
}