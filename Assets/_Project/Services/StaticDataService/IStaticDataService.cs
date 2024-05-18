using _Project.StaticData;
using UnityEngine;

namespace _Project.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Initialize();
        GameObject PlayerPrefab { get; }
        LevelData GetLevelStaticData(int levelIndex);
    }
}