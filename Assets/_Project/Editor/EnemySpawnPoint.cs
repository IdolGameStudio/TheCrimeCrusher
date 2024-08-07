using _Project.Scripts.GamePlay.Levels;
using UnityEditor;
using UnityEngine;

namespace _Project.Editor
{
    [CustomEditor(typeof(EnemyStartPoint))]
    public class EnemySpawnPoint: UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(EnemyStartPoint spawnPoint, GizmoType gizmoType)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawnPoint.transform.position, 0.5f);
        }
    }
}