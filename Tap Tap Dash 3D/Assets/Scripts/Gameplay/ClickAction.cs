using UnityEngine;

public class ClickAction : MonoBehaviour
{
	[SerializeField] PlayerMovement _player;
	
	public void OnClick()
	{
		_player.DoAction();
	}
}
