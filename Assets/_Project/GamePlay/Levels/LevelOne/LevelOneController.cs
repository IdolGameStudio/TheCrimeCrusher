using System.Collections.Generic;
using _Project.GamePlay.NPC;
using UnityEngine;

namespace _Project.GamePlay.Levels.LevelOne
{
    public class LevelOneController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _allNPCs;
        
        public void ChangeNPCs(int nPCsIndex)
        {
            _allNPCs[nPCsIndex].GetComponent<NPCDied>().Dead();
            if(nPCsIndex < _allNPCs.Count - 1) _allNPCs[nPCsIndex + 1].SetActive(true);
        }
    }
}