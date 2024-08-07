﻿using _Project.Scripts.UI.Interface;

namespace _Project.Scripts.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly InterfaceController.Factory _interFactory;
        
        private InterfaceController _interface;

        public UIFactory(InterfaceController.Factory interFactory)
        {
            _interFactory = interFactory;
        }
        public InterfaceController CreateRootUI()
        {
            _interface = _interFactory.Create();
            return _interface;
        }

        public void Cleanup()
        {
            
        }
    }
}