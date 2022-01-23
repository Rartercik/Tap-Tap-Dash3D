using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[CreateAssetMenu(menuName = "ShopData", fileName = "Shop")]
public class ShopData : ScriptableObject
{
	public SaveData Data;
	
	[SerializeField] Material _playerMaterial;
	
	private string _path;
	
	void Awake()
	{
		Data = new SaveData(_playerMaterial);
		
		#if UNITY_ANDROID && !UNITY_EDITOR
			_path = Path.Combine(Application.persistentDataPath, "ShopData.json");
		#else
			_path = Path.Combine(Application.dataPath, "ShopData.json");
		#endif
		
		if(File.Exists(_path))
		{
			Data = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path));
		}
	}
	
	public void SerializeData()
	{
		File.WriteAllText(_path, JsonUtility.ToJson(Data));
	}
	
	public void AddMoney(int count)
	{
		Data.Money += count;
	}
	
	[Serializable]
	public class SaveData
	{
		public Material Materials;
		public int Money;
		
		public SaveData(Material material)
		{
			Materials = material;
		}
	}
}
