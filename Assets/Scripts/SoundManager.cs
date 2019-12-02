using UnityEngine;

namespace WickedStudios
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource efxSource;
        public AudioSource musicSource;

        public static SoundManager instance ;
        public float lowPitchRange = .95f;
        public float highPitchRange = .4f;

        private void Start()
        {
            instance = this;
        }
        private void Update()
        {
      
        }

        void Awake()
        {
            Debug.Log("On Awake Sound Manager");
            DontDestroyOnLoad(transform.gameObject);
        }


        //Used to play single sound clips.
        public void PlaySingle(AudioClip clip)
        {
            efxSource.volume = .2f;
            efxSource.clip = clip;

            //Play the clip.
            efxSource.Play();
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
            Debug.Log("Stopping current audio");
            AudioSource currentAudio = GetComponent<AudioSource>();
            if (currentAudio)
            {
                currentAudio.Stop();
            }
        }
    }
}
