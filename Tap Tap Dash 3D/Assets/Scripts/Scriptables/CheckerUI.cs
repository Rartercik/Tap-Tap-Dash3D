using UnityEngine;
using System;

[CreateAssetMenu(menuName = "UiChecker", fileName = "MainUiChecker")]
public class CheckerUI : ScriptableObject
{
	public event Action AllSwitchActions;
	
	public void SwitchAll()
	{
		AllSwitchActions.Invoke();
	}
}
