using UnityEngine;

namespace HackedDesign
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        AudioManager()
        {
            Instance = this;
        }         
    }
}