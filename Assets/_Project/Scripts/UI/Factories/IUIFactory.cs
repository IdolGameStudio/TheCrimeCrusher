using _Project.Scripts.UI.Interface;

namespace _Project.Scripts.UI.Factories
{
    public interface IUIFactory
    {
        void Cleanup();
        InterfaceController CreateRootUI();
    }
}