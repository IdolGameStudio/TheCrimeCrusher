using Zenject;

namespace _Project.UI.Factories
{
    public class UIFactoryInstaller : Installer<UIFactoryInstaller>
    {
        public override void InstallBindings()
        {
            // bind ui sub-factories here
            
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }
    }
}