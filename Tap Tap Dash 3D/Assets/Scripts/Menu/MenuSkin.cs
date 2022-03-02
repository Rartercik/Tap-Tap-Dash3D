using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSkin : MonoBehaviour
{
    [SerializeField] ChooseSkin _skin;

    private string _skinName;

    private void Awake()
    {
        _skinName = _skin.PlayerSkinName;
        MenuSkinController.ChooseSkinEvent += ChangeActive;
        gameObject.SetActive(MenuSkinController.CurrentSkinName == _skinName);
    }
    private void OnDestroy()
    {
        MenuSkinController.ChooseSkinEvent -= ChangeActive;
    }

    private void ChangeActive()
    {
        gameObject.SetActive(MenuSkinController.CurrentSkinName == _skinName);
    }
}
