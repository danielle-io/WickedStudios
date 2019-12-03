using UnityEngine;

namespace WickedStudios
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource efxSource;
        public AudioSource backgroundMusic;

        public AudioClip intro;
        public AudioClip level1;
        public AudioClip level2;
        public AudioClip loseGame;
        public AudioClip winGame;

        public static SoundManager instance = null;
        public float lowPitchRange = .95f;
        public float highPitchRange = .4f;

        private void Start()
        {
        }

        void Awake()
        {
            instance = this;

            Debug.Log("On Awake Sound Manager");
            PlayLevelAudio(0);
            DontDestroyOnLoad(transform.gameObject);
        }

        public void PlaySingle(AudioClip clip)
        {
            efxSource.volume = .2f;
            efxSource.clip = clip;
            efxSource.Play();
        }

        public void PlayBackgroundMusic(AudioClip clip)
        {
            backgroundMusic.clip = clip;
            backgroundMusic.Play();
        }


        //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
        public void RandomizeSfx(params AudioClip[] clips)
        {
        
            //Generate a random number between 0 and the length of our array of clips passed in.
            int randomIndex = Random.Range(0, clips.Length);

            //Choose a random pitch to play back our clip at between our high and low pitch ranges.
            //float randomPitch = Random.Range(lowPitchRange, highPitchRange);

            //Set the pitch of the audio source to the randomly chosen pitch.
            //efxSource.pitch = randomPitch;

            //Set the clip to the clip at our randomly chosen index.
            efxSource.clip = clips[randomIndex];

            efxSource.volume = 0.2f;

            //Play the clip.
            efxSource.Play();
        }

        public void StopCurrentAudio()
        {
            AudioSource[] allAudio = FindObjectsOfType<AudioSource>(); 

            for (int i = 0; i < allAudio.Length; i++)
            {
                Debug.Log("Stopping current audio");
                AudioSource currentAudio = allAudio[i];
                if (currentAudio)
                {
                    currentAudio.Stop();
                }
            }
        }

        public void PlayLevelAudio(int level)
        {
            switch (level)
            {
                case 0:
                    PlayBackgroundMusic(intro);
                    break;
                case 1:
                    PlayBackgroundMusic(level1);
                    break;
                case 2:
                    PlayBackgroundMusic(level2);
                    break;
                case -1:
                    PlayBackgroundMusic(loseGame);
                    break;
                case 3:
                    PlayBackgroundMusic(winGame);
                    break;
                default:
                    Debug.Log("Error in sound manager");
                    break;
            }
        }
    }
}
