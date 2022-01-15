using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstMenu : MonoBehaviour
{
	[SerializeField] int mainMenu;
	
	private string key = "Was";
	
	void Start()
	{
		if(PlayerPrefs.HasKey(key)) SceneManager.LoadScene(mainMenu);
	}
	
	public void OnClick()
	{
		PlayerPrefs.SetString(key, key);
	}
}
