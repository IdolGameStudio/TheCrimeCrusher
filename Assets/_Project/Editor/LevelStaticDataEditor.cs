using System.Linq;
using _Project.GamePlay.Levels;
using _Project.StaticData.Enemy;
using _Project.StaticData.Level;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                levelData.LevelName = SceneManager.GetActiveScene().name;
                levelData.PlayerPosition = FindObjectOfType<PlayerStartPoint>().transform.position;
                levelData.Enemies = FindObjectsOfType<EnemyStartPoint>().Select(x=> new EnemiesLevelData(x.EnemyType, x.transform.position)).ToList();
            }
        }
    }
}