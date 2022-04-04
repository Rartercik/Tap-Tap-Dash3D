using UnityEngine;

public abstract class ActionPlate : MonoBehaviour
{
	[SerializeField] protected ActionPlate next;

    public abstract void DoAction(PlayerMovement player);
}
