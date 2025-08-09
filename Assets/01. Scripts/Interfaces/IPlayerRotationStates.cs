public interface IPlayerRotationStates
{
    public void EnterState(PlayerRotation player);

    public void UpdatePerState();

    public void ExitState();
}
