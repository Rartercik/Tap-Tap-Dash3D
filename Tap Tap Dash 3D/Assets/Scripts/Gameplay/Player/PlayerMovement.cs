using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(RotationMovement))]
[RequireComponent(typeof(VerticalMovement))]
[RequireComponent(typeof(Movement))]
public class PlayerMovement : MonoBehaviour
{
    public ActionPlate NextActionPlate;
    public PlayerData Data;

    [HideInInspector]
    public MovementInformation LastUpdate;

    [HideInInspector]
    public RotationMovement RotationMovement;

    [HideInInspector]
    public VerticalMovement VerticalMovement;

    [HideInInspector]
    public Movement Movement;

    [SerializeField] float _acceleration;
	
    private void Awake()
    {
        RotationMovement = GetComponent<RotationMovement>();
        VerticalMovement = GetComponent<VerticalMovement>();
        Movement = GetComponent<Movement>();

        LastUpdate = new MovementInformation(Movement.Speed, VerticalMovement.JumpDuration, _acceleration, 
            RotationMovement.StartCameraRotationDuration,
            RotationMovement.RotationDuration, NextActionPlate);
    }

    private void FixedUpdate()
    {
        Accelerate();
    }
    
    public void StopRotation()
    {
        RotationMovement.StopRotation();
    }

    public void DoAction()
    {
    	if(NextActionPlate != null)
    		NextActionPlate.DoAction(this);
    }
    
    public void StartRotation(float rotation, ActionPlate next, Vector3 d)
    {
        RotationMovement.PrepareRotation(rotation, d);
    	NextActionPlate = next;
    }
    
    public void Jump(ActionPlate next)
    {
        VerticalMovement.Jump();
    	NextActionPlate = next;
    }
    
    public void ChangeValues(MovementInformation info)
    {
        LastUpdate = info;
        _acceleration = info.Acceleration;
        NextActionPlate = info.Next;

        Movement.ChangeValues(info);
        VerticalMovement.ChangeValues(info);
        RotationMovement.ChangeValues(info);
    }

    private void Accelerate()
    {
        Movement.Accelerate(_acceleration);
        VerticalMovement.Accelerate(_acceleration);
        RotationMovement.Accelerate(_acceleration);
    }
}