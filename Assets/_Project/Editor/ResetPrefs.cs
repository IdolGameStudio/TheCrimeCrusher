using UnityEditor;
using UnityEngine;

namespace _Project.Editor
{
    public class ResetPrefs
    {
        [MenuItem("Tools/ResetPrefs")]
        public static void Reset()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }        
    }
}