using UnityEngine;

namespace _Project.Infrastructure
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}