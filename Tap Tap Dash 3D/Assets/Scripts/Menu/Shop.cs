using UnityEngine;

public class Shop : MonoBehaviour
{
	[SerializeField] CheckerUI _mainChecker;
    
    public void OnClick()
    {
    	_mainChecker.SwitchAll();
    }
}
