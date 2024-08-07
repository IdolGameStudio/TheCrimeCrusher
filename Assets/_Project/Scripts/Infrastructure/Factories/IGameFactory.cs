using System.Collections.Generic;
using _Project.Scripts.UI.HUD;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Factories
{
    public interface IGameFactory
    {
        IHUDRoot CreateHUD();
        void Cleanup();
        void CreatePlayer();
        GameObject Player { get; }
        List<GameObject> Enemies { get; }
        void CreateEnemyInLevel();
    }
}