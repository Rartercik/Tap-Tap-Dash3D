using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(VerticalMovement))]
public class Movement : MonoBehaviour
{
    [SerializeField] float _speed;

    private PlayerMovement _mainMovement;
    private VerticalMovement _verticalMovement;

    private Rigidbody rb;
    private Vector3 _direction = Vector3.forward;

    public Vector3 Direction
    {
        set
        {
            _direction = value;
        }
    }
    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            if (value < 0)
                _speed = 0;
            else if (value > _mainMovement.Data.MaxSpeed)
                _speed = _mainMovement.Data.MaxSpeed;
            else
                _speed = value;
        }
    }
    public bool IsJumping => _verticalMovement.IsJumping;
    public float JumpStartPositionY => _verticalMovement.JumpStartPositionY;
    public float JumpProgress => _verticalMovement.Progress;

    private void Awake()
    {
        _mainMovement = GetComponent<PlayerMovement>();
        _verticalMovement = GetComponent<VerticalMovement>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void ChangeValues(MovementInformation info)
    {
        Speed = info.Speed;
    }
    public void Accelerate(float acceleration)
    {
        Speed *= acceleration;
    }
    private void Move()
    {
        var finalDiraction = _direction * Speed * Time.fixedDeltaTime;

        var jumpParameter = IsJumping
            ? JumpStartPositionY + _mainMovement.Data.JumpCurve.Evaluate(JumpProgress) * 
                _mainMovement.Data.JumpHeight
            : transform.position.y;

        rb.MovePosition(new Vector3(transform.position.x + finalDiraction.x,
                                    jumpParameter,
                                    transform.position.z + finalDiraction.z));
    }
}
