using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings", fileName = "GameSettings")]
public class GameSettings : ScriptableObject
{
	public void InitializeSettings()
	{
		Application.targetFrameRate = 30;
	}
}
