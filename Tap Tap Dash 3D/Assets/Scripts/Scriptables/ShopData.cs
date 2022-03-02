using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShopData", fileName = "Shop")]
public class ShopData : ScriptableObject
{
	public SaveData Data;
	
	[SerializeField] string _playerSkinName;
	
	private string _playerSkinString = "PlayerSkin";
	private string _playerMoneyString = "PlayerMoney";

	public void Initialize()
	{
		Data = new SaveData(_playerSkinName);

		if (PlayerPrefs.HasKey(_playerSkinString))
			Data.PlayerSkinName = PlayerPrefs.GetString(_playerSkinString);
		if (PlayerPrefs.HasKey(_playerMoneyString))
			Data.Money = PlayerPrefs.GetInt(_playerMoneyString);
	}

	public void SerializeData()
	{
		PlayerPrefs.SetString(_playerSkinString, Data.PlayerSkinName);
		PlayerPrefs.SetInt(_playerMoneyString, Data.Money);
	}
	
	public void AddMoney(int count)
	{
		Data.Money += count;
	}
}
