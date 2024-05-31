using System.Linq;
using _Project.GamePlay.Levels;
using _Project.StaticData.Level;
using UnityEditor;
using UnityEngine;

namespace _Project.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LevelStaticData levelData = (LevelStaticData)target;
            if (GUILayout.Button("Collect"))
            {
                levelData.PlayerPosition = FindObjectOfType<PlayerStartPoint>().transform.position;
                levelData.Enemies = FindObjectsOfType<EnemyStartPoint>().Select(x=> new EnemiesData(x.EnemyType, x.transform.position)).ToList();
            }
        }
    }
}