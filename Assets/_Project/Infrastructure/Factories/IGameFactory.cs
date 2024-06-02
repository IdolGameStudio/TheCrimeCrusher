using _Project.UI.HUD;
using UnityEngine;

namespace _Project.Infrastructure.Factories
{
    public interface IGameFactory
    {
        IHUDRoot CreateHUD();
        void Cleanup();
        void CreatePlayer();
        void CreateLevel(int level);
        GameObject Player { get; }
        void CreateEnemyInLevel(int level);
    }
}