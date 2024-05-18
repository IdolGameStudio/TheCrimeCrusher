using System.Collections.Generic;
using UnityEngine;

namespace _Project.StaticData
{
    [CreateAssetMenu(fileName = "LevelStaticData", menuName = "StaticData/LevelStaticData")]
    public class LevelStaticData: ScriptableObject
    {
        public List<LevelData> LevelsData;
    }
}