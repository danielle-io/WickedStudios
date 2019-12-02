using UnityEngine;

namespace WickedStudios
{
    public class Quit : MonoBehaviour
    {
        public void Quitter()
        {
            Application.Quit();
        }
        void Awake()
        {
            Debug.Log("In game over, audio should be stopping");
            SoundManager.instance.StopCurrentAudio();
        }
    }
}

