using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelStation : MonoBehaviour
{
    public int Level;
    public Transform CollectablesParent;

    [SerializeField] Transform _playerStart;
    [SerializeField] PlayerEnding _playerEnding;
    [SerializeField] PlayerFinder _playerInfo;
	[SerializeField] ShopData _shopInformation;
	[SerializeField] ActionPlate next;
	[SerializeField] float playerSpeed = 5;
	[SerializeField] float jumpDuration = 0.5f;
	[SerializeField] float playerAcceleration = 1;
	[SerializeField] float cameraRDuration = 0.5f;
	[SerializeField] float playerRDuration = 1;
	[SerializeField] Text text;
	[SerializeField] GameObject _effects;

    private MovementInformation _playerMovementInfo;
    private GameObject player;
    private PlayerMovement playerMovement;
	private Rigidbody _playerRigidbody;
	private bool levelStart;
	private float progress;
	private Vector3 playerStartPosition;
	private Animator _animator;
	
	void Start()
	{
        player = _playerInfo.Player.gameObject;
        _playerMovementInfo = new MovementInformation(playerSpeed, jumpDuration, playerAcceleration, cameraRDuration,
            playerRDuration, next);
		playerMovement = player.GetComponent<PlayerMovement>();

		_playerRigidbody = player.GetComponent<Rigidbody>();
		text.text = Level.ToString();
		_animator = GetComponent<Animator>();
		
		if(StartLevel.Level == Level)
		{
            player.transform.position = _playerStart.position;
			playerMovement.ChangeValues(_playerMovementInfo);
            _playerEnding.StartStation = _playerStart;
		}
	}
	
    void Update()
    {
    	if(levelStart)
    	{
    		if(progress < 1)
    		{
                GoToCenter();
    		}
    		else
    		{
                InitializeLevel();
    		}
    	}
    }
    void OnCollisionEnter(Collision other)
    {
    	if(other.gameObject.TryGetComponent<PlayerMovement>(out var p) && StartLevel.Level != Level)
    	{
    		_animator.SetTrigger("DoChange");
            SwitchMovementEnabled(false);
            levelStart = true;
    		playerStartPosition = player.transform.position;
    	}
    }
    
    public void StartEffects()
    {
    	_effects.SetActive(true);
    }

    private void GoToCenter()
    {
        progress += Time.deltaTime;
        var playerPosition = Vector3.Lerp(playerStartPosition, _playerStart.position, progress);
        _playerRigidbody.MovePosition(playerPosition);
    }
    private void InitializeLevel()
    {
        levelStart = false;
        SwitchMovementEnabled(true);
        StartLevel.Level = Level;
        var s = string.Format("{0} {1}", SceneManager.GetActiveScene().buildIndex, Level);
        PlayerPrefs.SetString(s, s);
        playerMovement.ChangeValues(_playerMovementInfo);
        _playerEnding.StartStation = _playerStart;
        _shopInformation.SerializeData();
    }
    private void SwitchMovementEnabled(bool arg)
    {
        playerMovement.enabled = arg;
        playerMovement.Movement.enabled = arg;
        playerMovement.RotationMovement.enabled = arg;
        playerMovement.VerticalMovement.enabled = arg;
    }
}
