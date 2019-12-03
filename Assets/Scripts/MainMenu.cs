using UnityEngine;

namespace WickedStudios
{
    public class MainMenu : MonoBehaviour
    {
        public AudioClip mainMenuSound;

        public void Start()
        {
        }
        public void PlaySound()
        {
            SoundManager.instance.PlaySingle(mainMenuSound);
        }
    }
}