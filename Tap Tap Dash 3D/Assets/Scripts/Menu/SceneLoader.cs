using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] int World;
	[SerializeField] int level;
	
	private Button button;
	
	void Start()
	{
		button = GetComponent<Button>();
		
		if(!PlayerPrefs.HasKey(World + " 1")) PlayerPrefs.SetString(World + " 1", World + " 1");
		
		if(!PlayerPrefs.HasKey(string.Format("{0} {1}", World, level)))
		{
			ColorBlock cb = button.colors;
			cb.normalColor = new Color(button.colors.normalColor.r,
			                           button.colors.normalColor.g,
			                           button.colors.normalColor.r,
			                           0.2f);
			cb.highlightedColor = new Color(button.colors.normalColor.r,
			                           button.colors.normalColor.g,
			                           button.colors.normalColor.r,
			                           0.2f);
			cb.selectedColor = new Color(button.colors.normalColor.r,
			                           button.colors.normalColor.g,
			                           button.colors.normalColor.r,
			                           0.2f);
 			button.colors = cb;
		}
	}
	
	public void LoadScene()
	{
		if(PlayerPrefs.HasKey(string.Format("{0} {1}", World, level)))
		{
			StartLevel.Level = level;
			SceneManager.LoadScene(World);
		}
	}
}
