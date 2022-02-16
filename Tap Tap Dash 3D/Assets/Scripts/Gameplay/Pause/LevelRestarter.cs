using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRestarter : MonoBehaviour
{
    [SerializeField] PlayerEnding _player;
    [SerializeField] GameObject _background;

    public void Restart()
    {
        _player.RestartLevel();
        _background.SetActive(false);
        Time.timeScale = 1;
    }
}
