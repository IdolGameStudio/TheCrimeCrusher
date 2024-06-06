using _Project.UI.HUD;
using UnityEngine;

namespace _Project.Infrastructure.Factories
{
    public interface IGameFactory
    {
        IHUDRoot CreateHUD();
        void Cleanup();
        void CreatePlayer();
        GameObject Player { get; }
        void CreateEnemyInLevel();
    }
}