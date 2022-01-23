using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Shop : MonoBehaviour
{
	[SerializeField] GameObject[] _itemsOff;
	[SerializeField] GameObject[] _itemsOn;
	[SerializeField] Image[] _buttonsOffImages;
	[SerializeField] Image[] _buttonsOnImages;
	[SerializeField] float duration;
	
	private Image[] _imagesOff;
	private Text[] _textsOff;
	private Image[] _imagesOn;
	private Text[] _textsOn;
	private bool _startSwitching;
	private float _progress;
	
    void Start()
    {
    	InitializeItems(_itemsOff, ref _imagesOff, ref _textsOff);
    	InitializeItems(_itemsOn, ref _imagesOn, ref _textsOn);
    }
    void Update()
    {
    	if(_startSwitching)
    	{
    		if(_progress < 1)
    		{
    			_progress += Time.deltaTime / duration;
    			var _progressOff = 1 - _progress;
    			ProcessSwitching(ref _imagesOn, ref _textsOn, _progress);
    			ProcessSwitching(ref _imagesOff, ref _textsOff, _progressOff);
    		}
    		else
    		{
    			_startSwitching = false;
    			foreach(var e in _buttonsOnImages)
    				e.raycastTarget = true;
    			_progress = 0;
    		}
    	}
    }
    
    public void OnClick()
    {
    	if(!_startSwitching)
    	{
    		_startSwitching = true;
    		foreach(var e in _buttonsOffImages)
    			e.raycastTarget = false;
    	}
    }
    private void InitializeItems(GameObject[] items, ref Image[] images, ref Text[] texts)
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
    	images = imageList.ToArray();
    	texts = textList.ToArray();
    }
    private void ProcessSwitching(ref Image[] images, ref Text[] texts, float progress)
    {
    	foreach(var e in images)
    		e.color = new Color(e.color.r, e.color.g, e.color.b, progress);
    	foreach(var e in texts)
    		e.color = new Color(e.color.r, e.color.g, e.color.b, progress);
    }
}
