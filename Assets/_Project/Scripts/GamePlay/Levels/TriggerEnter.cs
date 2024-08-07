using _Project.Scripts.GamePlay.Levels.LevelOne;
using _Project.Scripts.GamePlay.Player;
using UnityEngine;

namespace _Project.Scripts.GamePlay.Levels
{
    public class TriggerEnter : MonoBehaviour
    {
        [SerializeField] private LevelOneController _levelOneController;
        [SerializeField] private int _nPCsIndexToOff;
        
        private bool _onTrigger = false;

        private void OnTriggerEnter(Collider other)
        {
            if(_onTrigger) return;
            if (other.GetComponent<PlayerTag>())
            {
                _onTrigger = true;
                _levelOneController.ChangeNPCs(_nPCsIndexToOff);
            }
        }
    }
}