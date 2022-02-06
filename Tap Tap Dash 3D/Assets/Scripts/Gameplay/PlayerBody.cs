using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    public PlayerData PlayerDataInfo;

    [SerializeField] Transform _player;

    private void Update()
    {
        transform.position = _player.position;
        transform.rotation = _player.rotation;
    }
}
