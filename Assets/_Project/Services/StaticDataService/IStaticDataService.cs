using _Project.StaticData;
using _Project.StaticData.Level;
using _Project.StaticData.Player;
using UnityEngine;

namespace _Project.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Initialize();
        LevelData GetLevelStaticData(int levelIndex);
        PlayerStaticData PlayerData { get; }
    }
}