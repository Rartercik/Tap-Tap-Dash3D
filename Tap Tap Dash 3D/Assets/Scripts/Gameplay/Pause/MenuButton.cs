using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] int _menuSceneIndex;

    public void GoToMenu()
    {
        SceneManager.LoadScene(_menuSceneIndex);
        Time.timeScale = 1;
    }
}
