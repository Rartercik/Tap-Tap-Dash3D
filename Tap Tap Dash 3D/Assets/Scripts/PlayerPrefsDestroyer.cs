using UnityEngine;

public class PlayerPrefsDestroyer : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}
