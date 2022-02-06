using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStopBody : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<PlayerBody>(out var player))
        {
            player.PlayerDataInfo.EndGame();
        }
    }
}
