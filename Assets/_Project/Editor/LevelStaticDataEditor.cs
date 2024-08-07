using System.Linq;
using _Project.Scripts.GamePlay.Levels;
using _Project.Scripts.StaticData.Level;
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
                levelData.Enemies = FindObjectsOfType<EnemyStartPoint>().Select(x => new EnemiesLevelData(x.EnemyType, x.transform.position)).ToList();

                // Добавляем сохранение изменений
                EditorUtility.SetDirty(levelData);
                AssetDatabase.SaveAssets();
            }
        }
    }
}