namespace _Project.Infrastructure.FSM
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}