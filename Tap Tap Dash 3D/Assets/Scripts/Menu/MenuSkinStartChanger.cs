using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSkinStartChanger : MonoBehaviour
{
    [SerializeField] ShopData _shopData;

    private void Start()
    {
        MenuSkinController.ChangeSkin(_shopData.Data.PlayerSkinName);
    }
}
