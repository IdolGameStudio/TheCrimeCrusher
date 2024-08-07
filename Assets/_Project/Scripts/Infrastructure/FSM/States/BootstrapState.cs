using _Project.Scripts.Services.AdsService;
using _Project.Scripts.Services.StaticDataService;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.FSM.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine gameStateMachine;
        private readonly IAdsService adsService;
        private readonly IStaticDataService staticDataService;

        public BootstrapState(IGameStateMachine gameStateMachine,
            IAdsService adsService,
            IStaticDataService staticDataService)
        {
            Debug.Log("BootstrapState constructor");
            this.adsService = adsService;
            this.staticDataService = staticDataService;
            this.gameStateMachine = gameStateMachine;
            this.staticDataService = staticDataService;
        }

        public void Enter()
        {
            Debug.Log("BootstrapState Enter");
            
            InitServices();
            gameStateMachine.Enter<LoadPlayerProgressState>();
        }

        private void InitServices()
        {
            staticDataService.Initialize();
            adsService.Initialize();
        }

        public void Exit()
        {
            Debug.Log("BootstrapState Exit");
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}