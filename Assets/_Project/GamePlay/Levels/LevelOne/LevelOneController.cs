using System.Collections;
using System.Collections.Generic;
using _Project.GamePlay.NPC;
using UnityEngine;

namespace _Project.GamePlay.Levels.LevelOne
{
    public class LevelOneController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _allNPCs;
        [SerializeField] private float _timeToDied = 1.5f;
        
        public void ChangeNPCs(int nPCsIndex)
        {
            _allNPCs[nPCsIndex].GetComponent<NPCDied>().Dead();
            StartCoroutine(WaitToAwakeNPC(nPCsIndex));
        }

        private IEnumerator WaitToAwakeNPC(int nPCsIndex)
        {
            yield return new WaitForSeconds(_timeToDied);
            if(nPCsIndex < _allNPCs.Count - 1) _allNPCs[nPCsIndex + 1].GetComponent<AwakeNPC>().NPCAwake();
        }
    }
}