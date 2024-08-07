using _Project.Scripts.GamePlay.Player.PlayerAbility.Drone;
using UnityEditor;
using UnityEngine;

namespace _Project.Editor
{
    [CustomEditor(typeof(DroneAttack))]
    public class AbilityGUI: UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Activate"))
            {
                (target as DroneAttack).Activate();
            }
        }
    }
}