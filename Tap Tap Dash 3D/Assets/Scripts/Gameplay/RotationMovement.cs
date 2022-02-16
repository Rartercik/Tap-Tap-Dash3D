using System.Collections;
using System.Collections.Generic;
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
            if (value < _mainMovement.Data.MinRotationDuration)
                _rotationDuration = _mainMovement.Data.MinRotationDuration;
            else
                _rotationDuration = value;
        }
    }
    public float StartCameraRotationDuration => _startCameraRotationDuration;

    private void Awake()
    {
        _mainMovement = GetComponent<PlayerMovement>();
        _movement = GetComponent<Movement>();
        _camera.RotationDuration = _startCameraRotationDuration;
    }
    private void Update()
    {
        if (startRotate)
        {
            Rotate();
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
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
        startRotate = false;
        progress = 0;
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
        startRotate = true;
        startTransform = transform;
        endRotationY = yRotation;
    }
    private void Rotate()
    {
        if (progress < 1)
        {
            progress += Time.deltaTime / RotationDuration;

            transform.rotation = Quaternion.Lerp(startTransform.rotation, Quaternion.Euler(new Vector3(
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
    private float CalculateRotation(float r)
    {
        if (r == 0 || r == 360) return 0;
        if (r == 90) return 30;
        if (r == 270) return -30;
        return 90;
    }
}
