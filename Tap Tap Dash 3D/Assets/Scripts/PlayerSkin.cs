using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
	[SerializeField] ShopData _shop;
	
    void Start()
    {
    	GetComponent<Renderer>().material = _shop.Data.Materials;
    }
}
