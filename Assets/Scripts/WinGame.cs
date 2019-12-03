using UnityEngine;

namespace WickedStudios
{
    public class WinGame : MonoBehaviour
    {
        void Awake()
        {
            SoundManager.instance.StopCurrentAudio();
        }
        private void Start()
        {
            SoundManager.instance.PlayLevelAudio(3);
        }
    }
}



