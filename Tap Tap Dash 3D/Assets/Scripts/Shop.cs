using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	[SerializeField] GameObject[] _itemsOff;
	[SerializeField] Button[] _buttonsOff;
	[SerializeField] GameObject[] _itemsOn;
	[SerializeField] Button[] _buttonsOn;
	
	private Image[] _imagesOff;
	private Text[] _textsOff;
	[SerializeField] private Image[] _imagesOn;
	private Text[] _textsOn;
	private bool _startSwitching;
	private float _progress;
	
    void Start()
    {
    	InitializeItems(_itemsOff, _imagesOff, _textsOff);
    	InitializeItems(_itemsOn, _imagesOn, _textsOn);
    }
    void Update()
    {
    	if(_startSwitching)
    	{
    		if(_progress < 1)
    		{
    			_progress += Time.deltaTime;
    			var _progressOff = 1 - _progress;
    			ProcessSwitching(_imagesOn, _textsOn, _progress);
    			ProcessSwitching(_imagesOff, _textsOff, _progressOff);
    		}
    		else
    		{
    			_startSwitching = false;
    			foreach(var e in _buttonsOn)
    				e.interactable = true;
    			_progress = 0;
    		}
    	}
    }
    
    public void OnClick()
    {
    	if(!_startSwitching)
    	{
    		_startSwitching = true;
    		foreach(var e in _buttonsOff)
    			e.interactable = false;
    	}
    }
    private void InitializeItems(GameObject[] items, Image[] images, Text[] texts)
    {
    	var imageList = new List<Image>();
    	var textList = new List<Text>();
    	foreach(var e in items)
    	{
    		if(e.TryGetComponent<Image>(out var image))
    			imageList.Add(image);
    		else if(e.TryGetComponent<Text>(out var text))
    			textList.Add(text);
    		else Debug.LogError("No requred component");
    	}
    	Debug.Log(imageList.Count);
    	images = imageList.ToArray();
    	texts = textList.ToArray();
    }
    private void ProcessSwitching(Image[] images, Text[] texts, float progress)
    {
    	foreach(var e in images)
    		e.color = new Color(e.color.r, e.color.g, e.color.b, progress);
    	foreach(var e in texts)
    		e.color = new Color(e.color.r, e.color.g, e.color.b, progress);
    }
}
