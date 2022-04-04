using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
	[SerializeField] ShopData _shop;
    [SerializeField] CollectParameters _collectParameter;
    [SerializeField] Text _text;
    
    private int _count;
    
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.TryGetComponent<Collectable>(out var collect))
		{
			_count += _collectParameter.Addition;
			_text.text = _count.ToString();
			_shop.AddMoney(_collectParameter.Addition);
			other.gameObject.SetActive(false);
		}
	}

    public void ResetValues()
    {
		if (_text != null)
		{
			_count = 0;
			_text.text = "0";
		}
    }
}
