using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
	[SerializeField] ShopData _shop;
    [SerializeField] string _skinName;

    private void Awake()
    {
        if (_shop.Data.PlayerSkinName != _skinName)
            gameObject.SetActive(false);
    }
}
