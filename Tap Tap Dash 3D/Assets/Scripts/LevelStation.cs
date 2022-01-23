using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelStation : MonoBehaviour
{
	public int Level;
	
	[SerializeField] GameObject player;
	[SerializeField] float _playerHeight;
	[SerializeField] ActionPlate next;
	[SerializeField] float playerSpeed = 5;
	[SerializeField] float jumpDuration = 0.5f;
	[SerializeField] float playerAcceleration = 1;
	[SerializeField] float cameraRDuration = 0.5f;
	[SerializeField] float playerRDuration = 1;
	[SerializeField] Text text;
	[SerializeField] GameObject _effects;
	
	private PlayerMovement playerMovement;
	private Rigidbody _playerRigidbody;
	private bool levelStart;
	private float progress;
	private Vector3 playerStartPosition;
	private Animator _animator;
	
	void Start()
	{
		playerMovement = player.GetComponent<PlayerMovement>();
		_playerRigidbody = player.GetComponent<Rigidbody>();
		text.text = Level.ToString();
		_animator = GetComponent<Animator>();
		
		if(StartLevel.Level == Level)
		{
			player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
			playerMovement.ChangeValues(playerSpeed, jumpDuration, playerAcceleration, cameraRDuration, playerRDuration, next);
		}
	}
	
    void Update()
    {
    	if(levelStart)
    	{
    		if(progress < 1)
    		{
    			progress += Time.deltaTime;
    			var playerPosition = Vector3.Lerp(playerStartPosition, new Vector3(transform.position.x,
    		                                                                			  _playerHeight,
    		                                                                			  transform.position.z), progress);
    			_playerRigidbody.MovePosition(playerPosition);
    		}
    		else
    		{
    			levelStart = false;
    			playerMovement.enabled = true;
    			StartLevel.Level = Level;
    			var s = string.Format("{0} {1}", SceneManager.GetActiveScene().buildIndex, Level);
    			PlayerPrefs.SetString(s, s);
    			playerMovement.ChangeValues(playerSpeed, jumpDuration, playerAcceleration, cameraRDuration, playerRDuration, next);
    		}
    	}
    }
    void OnCollisionEnter(Collision other)
    {
    	if(other.gameObject.TryGetComponent<PlayerMovement>(out var p) && StartLevel.Level != Level)
    	{
    		_animator.SetTrigger("DoChange");
    		p.enabled = false;
    		levelStart = true;
    		playerStartPosition = player.transform.position;
    	}
    }
    
    public void StarsEffects()
    {
    	_effects.SetActive(true);
    }
}
