using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : ActionPlate
{
	public override void DoAction()
	{
		float angle = transform.localEulerAngles.y + 90f;
		player.StartRotation(angle, next, CalculateDiraction(angle));
		
		gameObject.SetActive(false);
	}
	
	private Vector3 CalculateDiraction(float angle)
	{
		if(angle == 0 || angle == 360) return Vector3.forward;
		if(angle == 90 || angle == -270) return Vector3.right;
		if(angle == -90 || angle == 270) return Vector3.left;
		return Vector3.back;
	}
}
