using System.Collections.Generic;
using UnityEngine;

namespace _Project.StaticData.Level
{
    [CreateAssetMenu(fileName = "Level", menuName = "StaticData/Level")]
    public class LevelStaticData: ScriptableObject
    {
        public List<LevelData> LevelsData;
    }
}