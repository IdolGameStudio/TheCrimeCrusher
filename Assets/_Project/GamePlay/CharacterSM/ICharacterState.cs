namespace _Project.GamePlay.CharacterSM
{
    public interface ICharacterState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}