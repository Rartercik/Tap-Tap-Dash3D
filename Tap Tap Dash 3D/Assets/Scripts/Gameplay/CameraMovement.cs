using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	[SerializeField] PlayerData _data;
	[SerializeField] Transform _rotationCenter;
	
	private float _rotationDuration;
	private bool _startRotate;
	private Transform _startTransform;
	private float _endRotationY;
	private float _progress;
	
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
	
    private void Update()
    {
        if(_startRotate)
        {
        	if(_progress < 1)
        	{
        		_progress += Time.deltaTime / RotationDuration;
        		
        		_rotationCenter.rotation = Quaternion.Lerp(_startTransform.rotation, Quaternion.Euler(new Vector3(
        																	_startTransform.eulerAngles.x,
        		                                                            _endRotationY,
        		                                                            _startTransform.eulerAngles.z)), _progress);
        	}
        	else
        	{
        		_startRotate = false;
        		_progress = 0;
        	}
        }
    }
    
    public void Rotate(float yRotation)
    {
    	_startRotate = true;
    	_startTransform = _rotationCenter;
    	_endRotationY = yRotation;
    }
    public void StopRotate()
    {
        _startRotate = false;
        _progress = 0;
    }
}
