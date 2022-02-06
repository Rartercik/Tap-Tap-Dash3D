using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterGameSettings : MonoBehaviour
{
    [SerializeField] GameSettings _game;

    private void Awake()
    {
        _game.InitializeSettings();
    }
}
