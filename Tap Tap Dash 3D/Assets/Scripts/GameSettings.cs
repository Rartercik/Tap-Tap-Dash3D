using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings", fileName = "GameSettings")]
public class GameSettings : ScriptableObject
{
	void Awake()
	{
		Application.targetFrameRate = 30;
	}
}
