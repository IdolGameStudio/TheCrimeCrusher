﻿using _Project.UI.HUD;
using UnityEngine;

namespace _Project.Infrastructure.Factories
{
    public interface IGameFactory
    {
        IHUDRoot CreateHUD();
        void Cleanup();
        void CreatePlayer();
        void CreateLevel(int startLevelIndex);
        GameObject Player { get; }
    }
}