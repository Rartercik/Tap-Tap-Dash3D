using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class SceneLoader : MonoBehaviour
{
	[SerializeField] int _world;
	[SerializeField] int _level;
	
	private Button button;
	
	private void Start()
	{
		button = GetComponent<Button>();
		
		if(!PlayerPrefs.HasKey(_world + " 1")) PlayerPrefs.SetString(_world + " 1", _world + " 1");
		
		if(!PlayerPrefs.HasKey(string.Format("{0} {1}", _world, _level)))
		{
			ColorBlock cb = button.colors;
			var disableColor = new Color(cb.normalColor.r, cb.normalColor.g, cb.normalColor.b, 0.2f);
			cb.normalColor = disableColor;
			cb.highlightedColor = disableColor;
			cb.selectedColor = disableColor;
			button.colors = cb;
		}
	}
	
	public void LoadScene()
	{
		if(PlayerPrefs.HasKey(string.Format("{0} {1}", _world, _level)))
		{
			StartLevel.Level = _level;
			SceneManager.LoadScene(_world);
		}
	}
}
