using UnityEngine;

namespace WickedStudios
{
    public class Level2Intro : MonoBehaviour
    {
        void Awake()
        {
            SoundManager.instance.StopCurrentAudio();
        }

        private void Start()
        {
            SoundManager.instance.PlayLevelAudio(0);
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}

