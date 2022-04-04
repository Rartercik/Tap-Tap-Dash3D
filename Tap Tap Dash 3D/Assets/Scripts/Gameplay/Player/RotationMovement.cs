using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Movement))]
public class RotationMovement : MonoBehaviour
{
    [SerializeField] CameraMovement _camera;

    [SerializeField] float _rotationDuration;
    [SerializeField] float _startCameraRotationDuration;

    private PlayerMovement _mainMovement;
    private Movement _movement;

    private bool _startRotate;
    private Transform _startTransform;
    private float _endRotationY;
    private float _progress;
    private Transform _cacheTransform;

    public float RotationDuration
    {
        get
        {
            return _rotationDuration;
        }
        set
        {
            if (value < _mainMovement.Data.MinRotationDuration)
                _rotationDuration = _mainMovement.Data.MinRotationDuration;
            else
                _rotationDuration = value;
        }
    }
    public float StartCameraRotationDuration => _startCameraRotationDuration;

    private void Awake()
    {
        _cacheTransform = transform;
        _mainMovement = GetComponent<PlayerMovement>();
        _movement = GetComponent<Movement>();
        _camera.RotationDuration = _startCameraRotationDuration;
    }
    private void Update()
    {
        if (_startRotate)
        {
            Rotate();
        }
        else
        {
            _cacheTransform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

    public void ChangeValues(MovementInformation info)
    {
        _camera.RotationDuration = info.CameraRDuration;
        RotationDuration = info.PlayerRDuration;
    }
    public void Accelerate(float acceleration)
    {
        _camera.RotationDuration /= acceleration;
        RotationDuration /= acceleration;
    }
    public void StopRotation()
    {
        _startRotate = false;
        _progress = 0;
        _camera.StopRotate();
    }
    public void PrepareRotation(float rotation, Vector3 direction)
    {
        StartRotation(rotation);
        _movement.Direction = direction;
        var cameraRot = CalculateRotation(rotation);
        _camera.Rotate(cameraRot);
    }
    private void StartRotation(float yRotation)
    {
        _startRotate = true;
        _startTransform = transform;
        _endRotationY = yRotation;
    }
    private void Rotate()
    {
        if (_progress < 1)
        {
            _progress += Time.deltaTime / RotationDuration;

            _cacheTransform.rotation = Quaternion.Lerp(_startTransform.rotation, Quaternion.Euler(new Vector3(
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
    private float CalculateRotation(float r)
    {
        if (r == 0 || r == 360) return 0;
        if (r == 90) return 30;
        if (r == 270) return -30;
        return 90;
    }
}
