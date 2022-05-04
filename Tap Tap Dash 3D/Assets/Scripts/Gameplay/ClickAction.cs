using UnityEngine;
using Zenject;

public class ClickAction : MonoBehaviour
{
	[Inject] PlayerMovement _player;
	
	public void OnClick()
	{
		_player.DoAction();
	}
}
