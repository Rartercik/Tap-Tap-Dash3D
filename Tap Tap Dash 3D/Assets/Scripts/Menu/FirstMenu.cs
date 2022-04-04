using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstMenu : MonoBehaviour
{
	[SerializeField] int _mainMenu;
	
	private string _key = "Was";
	
	private void Start()
	{
		if(PlayerPrefs.HasKey(_key)) SceneManager.LoadScene(_mainMenu);
	}
	
	public void OnClick()
	{
		PlayerPrefs.SetString(_key, _key);
	}
}
