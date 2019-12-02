using UnityEngine;

namespace WickedStudios
{
    public class WinGame : MonoBehaviour
    {
        void Awake()
        {
            SoundManager.instance.StopCurrentAudio();
        }
    }
}



