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
            GameManager.instance.ResetPlayerAndAntiPlayerPoints();
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
            if (GameManager.instance.GetPlayerPoints() <= -5)
            {
                return -1;
            }
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

