using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

[CreateAssetMenu(menuName = "ShopData", fileName = "Shop")]
public class ShopData : ScriptableObject
{
	public SaveData Data;
	
	[SerializeField] string _playerSkinName;
	
	private string _path;
	
	void Awake()
	{
		Data = new SaveData(_playerSkinName);
		
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
		public string PlayerSkinName;
		public int Money;
		
		public SaveData(string playerSkinName)
		{
			PlayerSkinName = playerSkinName;
		}
	}
}
