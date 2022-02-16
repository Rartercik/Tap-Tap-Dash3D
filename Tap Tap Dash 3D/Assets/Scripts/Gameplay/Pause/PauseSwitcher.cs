using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSwitcher : MonoBehaviour
{
    [SerializeField] GameObject _pauseBackground;
    [SerializeField] bool _on;

    public void Pause()
    {
        _pauseBackground.SetActive(_on);
        Time.timeScale = _on ? 0 : 1;
    }
}
