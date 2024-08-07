using _Project.Scripts.Infrastructure;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.FSM;
using _Project.Scripts.Services.AdsService;
using _Project.Scripts.Services.InputService;
using _Project.Scripts.Services.PlayerProgressService;
using _Project.Scripts.Services.RandomizerService;
using _Project.Scripts.Services.SaveLoadService;
using _Project.Scripts.Services.StaticDataService;
using _Project.Scripts.UI.Factories;
using GamePush;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CompositionRoot
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameBootstraperFactory();

            BindCoroutineRunner();

            BindSceneLoader();

            BindLoadingCurtain();

            BindGameStateMachine();

            BindStaticDataService();

            BindGameFactory();

            BindUIFactory();

            BindRandomizeService();

            BindPlayerProgressService();

            BindSaveLoadService();

            BindAdsService();

            BindInputService();
        }

        private void BindStaticDataService() =>
            Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();

        private void BindGameBootstraperFactory()
        {
            Container
                .BindFactory<GameBootstrapper, GameBootstrapper.Factory>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.GameBootstraper);
        }

        private void BindInputService()
        {
            if (GP_Device.IsMobile())
                Container.BindInterfacesAndSelfTo<MobileInputService>().AsSingle();
            else
                Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }

        private void BindAdsService() =>
            Container.BindInterfacesAndSelfTo<AdsService>().AsSingle();

        private void BindSaveLoadService()
        {
            Container
                .BindInterfacesAndSelfTo<SaveLoadService>()
                .AsSingle();
        }

        private void BindPlayerProgressService()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerProgressService>()
                .AsSingle();
        }

        private void BindRandomizeService() =>
            Container.BindInterfacesAndSelfTo<RandomizerService>().AsSingle();

        private void BindGameFactory()
        {
            Container
                .Bind<IGameFactory>()
                .FromSubContainerResolve()
                .ByInstaller<GameFactoryInstaller>()
                .AsSingle();
        }

        private void BindUIFactory()
        {
            Container
                .Bind<IUIFactory>()
                .FromSubContainerResolve()
                .ByInstaller<UIFactoryInstaller>()
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.CoroutineRunnerPath)
                .AsSingle();
        }

        private void BindSceneLoader() =>
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();

        private void BindLoadingCurtain() =>
            Container.Bind<ILoadingCurtain>().To<LoadingCurtain>()
                .FromComponentInNewPrefabResource(InfrastructureAssetPath.CurtainPath).AsSingle();

        private void BindGameStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GameStateMachineInstaller>()
                .AsSingle();
            Debug.Log("Bind IGameStateMachine");
        }
    }
}