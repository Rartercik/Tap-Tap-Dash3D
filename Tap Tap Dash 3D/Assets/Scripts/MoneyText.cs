using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
	[SerializeField] ShopData _data;
	
	void Start()
	{
		GetComponent<Text>().text = _data.Data.Money.ToString();
	}
}