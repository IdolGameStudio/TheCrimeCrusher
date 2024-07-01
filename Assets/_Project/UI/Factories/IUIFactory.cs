using _Project.UI.Interface;

namespace _Project.UI.Factories
{
    public interface IUIFactory
    {
        void Cleanup();
        InterfaceController CreateRootUI();
    }
}