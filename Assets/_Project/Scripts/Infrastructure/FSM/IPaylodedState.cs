namespace _Project.Scripts.Infrastructure.FSM
{
    public interface IPaylodedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}