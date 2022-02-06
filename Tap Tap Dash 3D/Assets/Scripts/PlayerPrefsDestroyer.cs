using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDestroyer : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}
