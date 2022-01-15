using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
	[SerializeField] PlayerMovement player;
	
	public void OnClick()
	{
		player.DoAction();
	}
}
