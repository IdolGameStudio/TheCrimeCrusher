using _Project.GamePlay.Levels.LevelOne;
using _Project.GamePlay.Player;
using UnityEngine;

namespace _Project.GamePlay.Levels
{
    public class TriggerEnter : MonoBehaviour
    {
        [SerializeField] private LevelOneController _levelOneController;
        [SerializeField] private int _nPCsIndexToOff;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerTag>()) _levelOneController.ChangeNPCs(0);
        }
    }
}