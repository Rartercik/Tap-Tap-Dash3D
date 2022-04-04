public struct MovementInformation
{
    public readonly float Speed;
    public readonly float JumpDuration;
    public readonly float Acceleration;
    public readonly float CameraRDuration;
    public readonly float PlayerRDuration;
    public readonly ActionPlate Next;

    public MovementInformation(float speed, float jumpDuration, float acceleration, float cameraRDuration,
        float playerRDuration, ActionPlate next)
    {
        Speed = speed;
        JumpDuration = jumpDuration;
        Acceleration = acceleration;
        CameraRDuration = cameraRDuration;
        PlayerRDuration = playerRDuration;
        Next = next;
    }
}
