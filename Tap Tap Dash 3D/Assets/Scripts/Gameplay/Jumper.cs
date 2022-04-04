public class Jumper : ActionPlate
{
	public override void DoAction(PlayerMovement player)
	{
		player.Jump(next);
		gameObject.SetActive(false);
	}
}
