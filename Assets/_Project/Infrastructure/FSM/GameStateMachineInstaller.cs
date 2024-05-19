using _Project.Infrastructure.FSM.States;
using UnityEngine;
using Zenject;

namespace _Project.Infrastructure.FSM
{
    public class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<IGameStateMachine, BootstrapState, BootstrapState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadPlayerProgressState, LoadPlayerProgressState.Factory>();
            Container.BindFactory<IGameStateMachine, LoadLevelState, LoadLevelState.Factory>();
            Container.BindFactory<IGameStateMachine, GameLoopState, GameLoopState.Factory>();
            

            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        
            Debug.Log("GameStateMachineInstaller");
        }
    }
}