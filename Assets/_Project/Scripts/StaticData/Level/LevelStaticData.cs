using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.StaticData.Level
{
    [CreateAssetMenu(fileName = "Level", menuName = "StaticData/Level")]
    public class LevelStaticData: ScriptableObject
    {
        public string LevelName;
        public Vector3 PlayerPosition;
        public List<EnemiesLevelData> Enemies;
    }
}