using UnityEngine;

public class StarterGameSettings : MonoBehaviour
{
    [SerializeField] GameSettings _game;
    [SerializeField] ShopData _shopData;

    private void Awake()
    {
        _game.InitializeSettings();
        _shopData.Initialize();
    }
}
