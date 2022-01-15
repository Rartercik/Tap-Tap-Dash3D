using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : ActionPlate
{
	public override void DoAction()
	{
		player.Jump(next);
		gameObject.SetActive(false);
	}
}
