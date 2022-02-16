using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMovement))]
public class VerticalMovement : MonoBehaviour
{
    [HideInInspector]
    public Animator MovementAnimator;

    [SerializeField] float _jumpDuration;

    private PlayerMovement _mainMovement;

    private Rigidbody rb;
    private bool jumpStart = false;
    private float jumpStartPositionY;
    private float timer;
    private float progress;

    public float JumpDuration
    {
        get
        {
            return _jumpDuration;
        }
        set
        {
            if (value < _mainMovement.Data.MinJumpDuration)
                _jumpDuration = _mainMovement.Data.MinJumpDuration;
            else
                _jumpDuration = value;
        }
    }
    public bool IsJumping => jumpStart;
    public float JumpStartPositionY => jumpStartPositionY;
    public float Progress => progress;

    private void Awake()
    {
        _mainMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (jumpStart)
        {
            ProcessJumping();
        }
        else
        {
            Fall();
        }
    }

    public void ChangeValues(MovementInformation info)
    {
        JumpDuration = info.JumpDuration;
    }
    public void Jump()
    {
        jumpStart = true;
        jumpStartPositionY = transform.position.y;
        if (!MovementAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            MovementAnimator.SetTrigger("Jump");
        else
            MovementAnimator.Play("Jump", 0, 0);
    }
    public void Accelerate(float acceleration)
    {
        JumpDuration /= acceleration;
    }
    private void ProcessJumping()
    {
        timer += Time.fixedDeltaTime;
        progress = timer / JumpDuration;

        if (timer > JumpDuration)
        {
            jumpStart = false;
            timer = 0;
            progress = 0;
        }
    }
    private void Fall()
    {
        var gravity = Vector3.down * _mainMovement.Data.GravityScale * PlayerData.GravityAcceleration;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}
