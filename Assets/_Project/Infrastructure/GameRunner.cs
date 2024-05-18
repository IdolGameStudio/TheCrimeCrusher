using UnityEngine;
using Zenject;

namespace _Project.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        GameBootstrapper.Factory gameBootstrapperFactory;

        [Inject]
        void Construct(GameBootstrapper.Factory bootstrapperFactory) => 
            this.gameBootstrapperFactory = bootstrapperFactory;

        private void Awake()
        {
            var bootstrapper = FindAnyObjectByType<GameBootstrapper>();
      
            if(bootstrapper != null) return;

            gameBootstrapperFactory.Create();
        }
    }
}