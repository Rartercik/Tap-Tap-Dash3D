using UnityEngine;

public class ChooseWorld : MonoBehaviour
{
	[SerializeField] GameObject _our;
	[SerializeField] GameObject[] _others;
	
	public void OnClick()
	{
		_our.SetActive(true);
		foreach(var e in _others)
			e.SetActive(false);
	}
}
