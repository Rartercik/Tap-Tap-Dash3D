using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class ChooseSkin : MonoBehaviour
{
	[SerializeField] ShopData _data;
	[SerializeField] Image _buttonImage;
	[SerializeField] Color _color;
	[SerializeField] Material _playerMaterial;
	[SerializeField] Text _currentMoney;
	[SerializeField] Text _costText;
	[SerializeField] int _cost;
	[SerializeField] string _jsonFileName;
	[SerializeField] bool _available;
	
	private SkinInformation _information;
	private string _path;
	
	void Awake()
	{
		_information = new SkinInformation();
		_information.Available = _available;
		#if UNITY_ANDROID && !UNITY_EDITOR
			_path = Path.Combine(Application.persistentDataPath, _jsonFileName + ".json");
		#else
			_path = Path.Combine(Application.dataPath, _jsonFileName + ".json");
		#endif
		
		if(File.Exists(_path))
		{
			_information = JsonUtility.FromJson<SkinInformation>(File.ReadAllText(_path));
		}
	}
    void Start()
    {
    	if(_costText != null)
    		_costText.text = _cost.ToString();
    	
    	if(_information.Available)
    	{
    		var startColor = new Color(_color.r, _color.g, _color.b, 0f);
    		_buttonImage.color = startColor;
    		if(_costText != null)
    			_costText.gameObject.SetActive(false);
    	}
    }
    
    public void OnClick()
    {
    	if(_information.Available == false)
    	{
    		if(_data.Data.Money >= _cost)
    		{
    			_data.Data.Money -= _cost;
    			_buttonImage.color = _color;
    			if(_costText != null)
    				_costText.gameObject.SetActive(false);
    			_currentMoney.text = _data.Data.Money.ToString();
    			_information.Available = true;
    			
    			File.WriteAllText(_path, JsonUtility.ToJson(_information));
    		}
    	}
    	else
    	{
    		_data.Data.Materials = _playerMaterial;
    	}
    }
    
    [Serializable]
    private class SkinInformation
    {
    	public bool Available;
    }
}
