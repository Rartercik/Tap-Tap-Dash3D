using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] CameraMovement _camera;
	[SerializeField] ActionPlate nextActionPlate;
	[SerializeField] float rotationDuration;
    [SerializeField] float acceleration;
    [SerializeField] float minY;
    [SerializeField] AnimationCurve jumpCurve;
    [SerializeField] float jumpDuration;
    [SerializeField] float jumpHeight;
    
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
    
    void Start()
    {
    	rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
    	if(startRotate)
        {
        	if(progressRotation < 1)
        	{
        		progressRotation += Time.deltaTime / rotationDuration;
        		
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
    	if(speed * acceleration < 15)
    		speed *= acceleration;
    	if(jumpDuration / acceleration > 0.16f)
    		jumpDuration /= acceleration;
    	if(_camera.RotationDuration / acceleration > 0.16f)
    		_camera.RotationDuration /= acceleration;
    	if(rotationDuration / acceleration > 0.33f)
    		rotationDuration /= acceleration;
    	
    	if(jumpStart)
    	{
    		timer += Time.fixedDeltaTime;
    		progress = timer / jumpDuration;
    		
    		if(timer > jumpDuration)
    		{
    			jumpStart = false;
    			rb.useGravity = true;
    			timer = 0;
    			progress = 0;
    		}
    	}
    	
    	var finalDiraction = direction * speed * Time.fixedDeltaTime;
    	var jumpParameter = jumpStart == true
    		? jumpStartPositionY + jumpCurve.Evaluate(progress) * jumpHeight
    		: transform.position.y;
    	var jumpDurationParameter = jumpStart == true
    		? jumpDuration
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
    
    public void ChangeValues(float _speed, float _jumpDuration, float _acceleration, float cameraRDuration, float platerRDuration,
                             ActionPlate _next)
    {
    	speed = _speed;
    	jumpDuration = _jumpDuration;
    	_camera.RotationDuration = cameraRDuration;
    	rotationDuration = platerRDuration;
    	acceleration = _acceleration;
    	nextActionPlate = _next;
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