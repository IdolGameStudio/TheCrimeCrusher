using System.Collections;
using UnityEngine;

namespace _Project.GamePlay.NPC
{
    public class NPCDied : MonoBehaviour
    {
        [SerializeField] private GameObject _deadFX;
        private float _timeToDied = 1.5f;

        public void Dead()
        {
            _deadFX.SetActive(true);
            StartCoroutine(CountDown());
        }

        private IEnumerator CountDown()
        {
            yield return new WaitForSeconds(_timeToDied);
            gameObject.SetActive(false);
        }
    }
}