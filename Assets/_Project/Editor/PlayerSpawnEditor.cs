using _Project.GamePlay.Levels;
using UnityEditor;
using UnityEngine;

namespace _Project.Editor
{
    [CustomEditor(typeof(PlayerStartPoint))]
    public class PlayerSpawnEditor: UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(PlayerStartPoint spawnPoint, GizmoType gizmoType)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(spawnPoint.transform.position, 0.5f);
        }
        
    }
}