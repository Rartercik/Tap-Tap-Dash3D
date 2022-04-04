using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
	[SerializeField] ShopData _data;
	
	private void Start()
	{
		GetComponent<Text>().text = _data.Data.Money.ToString();
	}
}
