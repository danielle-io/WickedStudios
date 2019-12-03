using UnityEngine;

namespace WickedStudios
{
    public class LevelTwo : Level
    {
        public GameObject fallerCatcher;
        public static LevelTwo instance = null;

        void Awake()
        {
            SoundManager.instance.StopCurrentAudio();
        }

        private void Start()
        {
            SoundManager.instance.PlayLevelAudio(2);
        }

        public override void SetupLevel(BoardManager bm)
        {
            bm.AddObjectToBoardAtPosition(fallerCatcher, new Vector3(0, -3.7f, 0));
        }

        public override int CheckLevelOver()
        {
            // Player has closed 5 brackets or hit 5 wrong brackets
            if (GameManager.instance.GetPlayerPoints() <= -5)
            {
                return -1;
            }
            // Player has closed 5 brackets or hit 5 wrong brackets
            if (GameManager.instance.GetPlayerPoints() >= 5)
            {
                return 1;
            }
            return 0;
        }

        public override string GetNextScene()
        {
            return "WinGame";
        }
    }
}

