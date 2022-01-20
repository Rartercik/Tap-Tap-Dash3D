using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] PlayerData _data;
	[SerializeField] CameraMovement _camera;
	[SerializeField] ActionPlate nextActionPlate;
    [SerializeField] float minY;
    
    [SerializeField] float _acceleration;
    [SerializeField] float _speed;
    [SerializeField] float _rotationDuration;
    [SerializeField] float _startCameraRotationDuration;
    [SerializeField] float _jumpDuration;
    
    private Rigidbody rb;
    private Vector3 direction = new Vector3(0, 0, 1);
    private bool jumpStart = false;
    private float jumpStartPositionY;
    private float timer;
    private float progress;
    
    private bool startRotate;
	private Transform startTransform;
	private float endRotationY;
	private float progressRotation;
    
	public float Speed
    {
    	get
    	{
    		return _speed;
    	}
    	set
    	{
    		if(value < 0)
    			_speed = 0;
    		else if(value > _data.MaxSpeed)
    			_speed = _data.MaxSpeed;
    		else
    			_speed = value;
    	}
    }
	public float RotationDuration
    {
    	get
    	{
    		return _rotationDuration;
    	}
    	set
    	{
    		if(value < _data.MinRotationDuration)
    			_rotationDuration = _data.MinRotationDuration;
    		else
    			_rotationDuration = value;
    	}
    }
	public float JumpDuration
    {
    	get
    	{
    		return _jumpDuration;
    	}
    	set
    	{
    		if(value < _data.MinJumpDuration)
    			_jumpDuration = _data.MinJumpDuration;
    		else
    			_jumpDuration = value;
    	}
    }
	
    void Start()
    {
    	rb = GetComponent<Rigidbody>();
    	_camera.RotationDuration = _startCameraRotationDuration;
    }
    
    void Update()
    {
    	if(startRotate)
        {
        	if(progressRotation < 1)
        	{
        		progressRotation += Time.deltaTime / RotationDuration;
        		
        		transform.rotation = Quaternion.Lerp(startTransform.rotation, Quaternion.Euler(new Vector3(
        																	startTransform.eulerAngles.x,
        		                                                            endRotationY,
        		                                                            startTransform.eulerAngles.z)), progressRotation);
        	}
        	else
        	{
        		startRotate = false;
        		progressRotation = 0;
        	}
        }
    }
    
    void FixedUpdate()
    {
    	Speed *= _acceleration;
    	JumpDuration /= _acceleration;
    	_camera.RotationDuration /= _acceleration;
    	RotationDuration /= _acceleration;
    	
    	if(jumpStart)
    	{
    		timer += Time.fixedDeltaTime;
    		progress = timer / JumpDuration;
    		
    		if(timer > JumpDuration)
    		{
    			jumpStart = false;
    			rb.useGravity = true;
    			timer = 0;
    			progress = 0;
    		}
    	}
    	
    	var finalDiraction = direction * Speed * Time.fixedDeltaTime;
    	
    	var jumpParameter = jumpStart
    		? jumpStartPositionY + _data.JumpCurve.Evaluate(progress) * _data.JumpHeight
    		: transform.position.y;
    	
    	var jumpDurationParameter = jumpStart
    		? JumpDuration
    		: 0;
    	
    	rb.MovePosition(new Vector3(transform.position.x + finalDiraction.x,
    	                            jumpParameter,
    	                            transform.position.z + finalDiraction.z));
    	
    	if(transform.position.y < minY)
        {
        	EndGame();
        }
    }
    
    public void DoAction()
    {
    	if(nextActionPlate != null)
    		nextActionPlate.DoAction();
    }
    
    public void Rotate(float rotation, ActionPlate next, Vector3 d)
    {
    	RotatePlayer(rotation);
    	var cameraRot = CalculateRotation(rotation);
    	_camera.Rotate(cameraRot);
    	direction = d;
    	nextActionPlate = next;
    }
    
    public void Jump(ActionPlate next)
    {
    	jumpStart = true;
    	rb.useGravity = false;
    	jumpStartPositionY = transform.position.y;
    	nextActionPlate = next;
    }
    
    public void ChangeValues(float speed, float jumpDuration, float acceleration, float cameraRDuration, float playerRDuration,
                             ActionPlate next)
    {
    	Speed = speed;
    	JumpDuration = jumpDuration;
    	_camera.RotationDuration = cameraRDuration;
    	RotationDuration = playerRDuration;
    	_acceleration = acceleration;
    	nextActionPlate = next;
    }
    
    private void EndGame()
    {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void RotatePlayer(float yRotation)
    {
    	startRotate = true;
    	startTransform = transform;
    	endRotationY = yRotation;
    }
    private float CalculateRotation(float r)
    {
    	if(r == 0 || r == 360) return 0;
    	if(r == 90) return 30;
    	if(r == 270) return -30;
    	return 90;
    }
}