using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "PlayerProperties", fileName = "MovementProperties")]
public class PlayerData : ScriptableObject
{
    public AnimationCurve JumpCurve;
    public float JumpHeight;
	
	public float MaxSpeed;
	public float MinRotationDuration;
	public float MinCameraRotationDuration;
    public float MinJumpDuration;
	public float GravityScale;
	[HideInInspector] public const float GravityAcceleration = 9.81f;

	public void EndGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
