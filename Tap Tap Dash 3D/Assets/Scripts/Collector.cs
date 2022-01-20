using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    [SerializeField] CollectParameters _collectParameter;
    [SerializeField] Text text;
    private int _count;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.TryGetComponent<Collectable>(out var collect))
		{
			_count += _collectParameter.Addition;
			text.text = _count.ToString();
			other.gameObject.SetActive(false);
		}
	}
}
