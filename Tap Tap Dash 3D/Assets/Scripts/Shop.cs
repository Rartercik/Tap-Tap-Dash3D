using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Shop : MonoBehaviour
{
	[SerializeField] CheckerUI _mainChecker;
    
    public void OnClick()
    {
    	_mainChecker.SwitchAll();
    }
}
