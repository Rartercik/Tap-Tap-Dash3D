using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionPlate : MonoBehaviour
{
    [SerializeField] PlayerFinder _playerInformation;
	[SerializeField] protected ActionPlate next;

    protected PlayerMovement player;

    private void Start()
    {
        player = _playerInformation.Player;
    }

    public abstract void DoAction();
}
