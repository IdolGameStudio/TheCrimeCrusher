using UnityEngine;

namespace _Project.GamePlay.CharacterSM.PlayerState
{
    public class PlayerIdle: ICharacterState
    {
        private Animator _animator;

        public PlayerIdle(Animator animator)
        {
            _animator = animator;
        } 
        public void Enter()
        {
            
        }

        public void Execute()
        {
        }

        public void Exit()
        {
        }
    }
}