using _Project.GamePlay.Camera;
using _Project.Infrastructure.Factories;
using _Project.UI.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Infrastructure.FSM.States
{
    public class LoadLevelState : IPaylodedState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain, IGameFactory gameFactory, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName)
        {
            Debug.Log($"LoadLevelState enter. Load scene {sceneName}");
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            Debug.Log("LoadLevelState exit");
        }

        private void OnLoaded()
        {
            _loadingCurtain.Hide();
            Debug.Log("LoadLevelState OnLoaded");
            _gameFactory.CreatePlayer();
            _gameFactory.CreateHUD();
            Camera.main.GetComponent<VirtualCameraControl>().VirtualCamera.Follow = _gameFactory.Player.transform;
            _gameFactory.CreateEnemyInLevel();
            _uiFactory.CreateRootUI();
            _gameStateMachine.Enter<GameLoopState>();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}