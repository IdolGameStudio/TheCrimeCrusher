namespace _Project.Scripts.Infrastructure.FSM
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}