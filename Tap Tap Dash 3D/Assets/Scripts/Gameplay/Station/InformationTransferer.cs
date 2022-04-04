using UnityEngine;

public class InformationTransferer : MonoBehaviour
{
	[SerializeField] StartPositor _playerStart;
	[SerializeField] ShopData _shopInformation;
	[SerializeField] ActionPlate _next;
	[SerializeField] float _playerSpeed = 5;
	[SerializeField] float _jumpDuration = 0.5f;
	[SerializeField] float _playerAcceleration = 1;
	[SerializeField] float _cameraRDuration = 0.5f;
	[SerializeField] float _playerRDuration = 1;

	private MovementInformation _playerMovementInfo;

    private void Awake()
    {
		_playerMovementInfo = new MovementInformation(_playerSpeed, _jumpDuration, _playerAcceleration, _cameraRDuration,
			_playerRDuration, _next);
	}

	public void TransferInformation(GameObject player)
    {
		player.GetComponent<PlayerMovement>().ChangeValues(_playerMovementInfo);
		player.GetComponent<PlayerEnding>().StartStation = _playerStart;
		_shopInformation.SerializeData();
	}
}
