namespace _Project.GamePlay.CharacterSM
{
    public class CharacterStateMachine
    {
        private ICharacterState currentState;

        public void ChangeState(ICharacterState newState)
        {
            if (newState == currentState )
                return;
            if (currentState != null )
                currentState.Exit();

            currentState = newState;
            currentState.Enter();
        }

        public void Update()
        {
            if (currentState != null)
                currentState.Execute();
        }
    }
}