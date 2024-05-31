using System.Collections.Generic;
using UnityEngine;

namespace _Project.StaticData.Level
{
    [CreateAssetMenu(fileName = "Level", menuName = "StaticData/Level")]
    public class LevelStaticData: ScriptableObject
    {
        public int LevelIndex;
        public GameObject Prefab;
        public Vector3 PlayerPosition;
        public List<EnemiesData> Enemies;
    }
}