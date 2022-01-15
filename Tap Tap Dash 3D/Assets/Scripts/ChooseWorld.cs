using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWorld : MonoBehaviour
{
	[SerializeField] GameObject our;
	[SerializeField] GameObject[] others;
	
	public void OnClick()
	{
		our.SetActive(true);
		foreach(var e in others)
			e.SetActive(false);
	}
}
