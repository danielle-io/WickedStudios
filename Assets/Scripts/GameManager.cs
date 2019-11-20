using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace WickedStudios
{                  
    public class GameManager : MonoBehaviour
    {
        public float levelStartDelay = 2f;

        //Delay between each Player turn.
        public float turnDelay = 0.1f;

        public static GameManager instance = null;

        // This will hold the current Level Script.
        public Level levelScript;
        public BoardManager bm;
        public int level = 1;

        private static int playerPoints = 0;
        private static int antiPlayerPoints = 0;

        void Awake()
        {
            bm = GetComponent<BoardManager>();
            
            if (instance == null)
            {
                instance = this;
            }

            // If instance already exists and it's not this:
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            
            // Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
            
            //Get a component reference to the attached BoardManager script
            //bm = GetComponent<BoardManager>();
            InitGame();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static public void CallbackInitialization()
        {
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }

        static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            //instance.level++;
            //instance.InitGame();
        }

        // Initializes the game for each level.
        void InitGame()
        {

            switch (level)
            {
                case 1:
                    levelScript = GetComponent<LevelOne>();
                    break;
                case 2:
                    levelScript = GetComponent<LevelTwo>();
                    break;
                case 3:
                    levelScript = GetComponent<LevelThree>();
                    break;
                default:
                    Debug.Log("default switch statement");
                    break;
            }
            // May want to have a check here to make sure
            // levelScript is properly initialized.
            bm.SetupScene(levelScript);
        }

        void Update()
        {
            if (levelScript.CheckLevelOver()){
                Debug.Log("LEVEL IS OVER");
                SceneManager.LoadScene("GameOver");
            }

            levelScript.SetLevelText();
        }

        public int GetLevel()
        {
            return level;
        }

        public void SetPlayerPoints(int points)
        {
            playerPoints += points;
        }

        public int GetPlayerPoints()
        {
            return playerPoints;
        }

        public void SetAntiPlayerPoints(int points)
        {
            antiPlayerPoints += points;
        }

        public int GetAntiPlayerPoints()
        {
            return antiPlayerPoints;
        }

        public bool GetLevelOver()
        {
            return levelScript.CheckLevelOver();
        }
    }
}
