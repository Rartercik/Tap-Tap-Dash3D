using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float RotationDuration;
	[SerializeField] Transform playerTransform;
	[SerializeField] Transform rotationCenter;
	
	private bool startRotate;
	private Transform startTransform;
	private float endRotationY;
	private float progress;
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
}
