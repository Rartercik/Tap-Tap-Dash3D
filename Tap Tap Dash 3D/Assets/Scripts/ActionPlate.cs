using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionPlate : MonoBehaviour
{
    [SerializeField] protected PlayerMovement player;
	[SerializeField] protected ActionPlate next;
	
	public abstract void DoAction();
}
