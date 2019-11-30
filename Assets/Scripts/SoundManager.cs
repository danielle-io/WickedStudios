using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


namespace WickedStudios
{
	public class SoundManager : MonoBehaviour 
	{
        public AudioSource efxSource;		

        //Drag a reference to the audio source which will play the music.
        public AudioSource musicSource;					
		public static SoundManager instance = null;		
		public float lowPitchRange = .95f;				
		public float highPitchRange = 1.05f;

        private void Update()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            if (activeScene.name == "Level1")
            {
                AudioSource currentAudio = GetComponent<AudioSource>();
                currentAudio.Stop();
            }
            if (activeScene.name == "Level2")
            {
                AudioSource currentAudio = GetComponent<AudioSource>();
                currentAudio.Stop();
            }
        }
        void Awake ()
		{
			//if (instance == null)
			//	instance = this;
			//else if (instance != this)
				//Destroy (gameObject);
			
			//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
			 DontDestroyOnLoad (gameObject);
		}
		
		
		//Used to play single sound clips.
		public void PlaySingle(AudioClip clip)
		{
			//Set the clip of our efxSource audio source to the clip passed in as a parameter.
			efxSource.clip = clip;
			
			//Play the clip.
			efxSource.Play ();
		}
		
		
		//RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
		public void RandomizeSfx (params AudioClip[] clips)
		{
			//Generate a random number between 0 and the length of our array of clips passed in.
			int randomIndex = Random.Range(0, clips.Length);
			
			//Choose a random pitch to play back our clip at between our high and low pitch ranges.
			float randomPitch = Random.Range(lowPitchRange, highPitchRange);
			
			//Set the pitch of the audio source to the randomly chosen pitch.
			efxSource.pitch = randomPitch;
			
			//Set the clip to the clip at our randomly chosen index.
			efxSource.clip = clips[randomIndex];
			
			//Play the clip.
			efxSource.Play();
		}
	}
}
