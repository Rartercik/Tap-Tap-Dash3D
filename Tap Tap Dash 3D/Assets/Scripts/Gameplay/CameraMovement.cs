using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] PlayerData _data;
	[SerializeField] Transform rotationCenter;
	
	private float _rotationDuration;
	private bool startRotate;
	private Transform startTransform;
	private float endRotationY;
	private float progress;
	
	public float RotationDuration
	{
		get
		{
			return _rotationDuration;
		}
		set
		{
			if(value < _data.MinCameraRotationDuration)
				_rotationDuration = _data.MinCameraRotationDuration;
			else
				_rotationDuration = value;
		}
	}
	
    void Update()
    {
        if(startRotate)
        {
        	if(progress < 1)
        	{
        		progress += Time.deltaTime / RotationDuration;
        		
        		rotationCenter.rotation = Quaternion.Lerp(startTransform.rotation, Quaternion.Euler(new Vector3(
        																	startTransform.eulerAngles.x,
        		                                                            endRotationY,
        		                                                            startTransform.eulerAngles.z)), progress);
        	}
        	else
        	{
        		startRotate = false;
        		progress = 0;
        	}
        }
    }
    
    public void Rotate(float yRotation)
    {
    	startRotate = true;
    	startTransform = rotationCenter;
    	endRotationY = yRotation;
    }
    public void StopRotate()
    {
        startRotate = false;
        progress = 0;
    }
}
