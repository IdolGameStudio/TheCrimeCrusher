using _Project.Infrastructure.FSM;
using _Project.Infrastructure.FSM.States;
using UnityEngine;
using Zenject;

namespace _Project.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine gameStateMachine;

        [Inject]
        void Construct(IGameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
        }
        
        private void Start()
        {
            gameStateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }

        public class Factory : PlaceholderFactory<GameBootstrapper>
        {
        }
    }
}