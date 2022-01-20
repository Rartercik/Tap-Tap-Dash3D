using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerProperties", fileName = "MovementProperties")]
public class PlayerData : ScriptableObject
{
    public AnimationCurve JumpCurve;
    public float JumpHeight;
	
	public float MaxSpeed;
	public float MinRotationDuration;
	public float MinCameraRotationDuration;
    public float MinJumpDuration;
}
