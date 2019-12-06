using UnityEngine;

namespace WickedStudios
{
    public class MainMenu : MonoBehaviour
    {
        public AudioClip mainMenuSound;

        private void Awake()
        {
            SoundManager.instance.StopCurrentAudio();
        }
       
         void Start()
        {
        }
        public void PlaySound()
        {
            SoundManager.instance.PlaySingle(mainMenuSound);
        }
    }
}