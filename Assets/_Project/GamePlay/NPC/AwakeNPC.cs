using System.Collections;
using UnityEngine;

namespace _Project.GamePlay.NPC
{
    public class AwakeNPC : MonoBehaviour
    {
        [SerializeField] private GameObject _awakeFX;
        [SerializeField] private GameObject _NPCMesh;

        public void NPCAwake()
        {
            _awakeFX.SetActive(true);
            StartCoroutine(WaitFXToAwake());
        }
        
        private IEnumerator WaitFXToAwake()
        {
            yield return new WaitForSeconds(1f);
            _NPCMesh.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _awakeFX.SetActive(false);
        }
    }
}