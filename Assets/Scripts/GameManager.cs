using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace WickedStudios
{                  
    public class GameManager : MonoBehaviour
    {

        //Time to wait before starting level, in seconds.
        public float levelStartDelay = 2f;

        //Delay between each Player turn.
        public float turnDelay = 0.1f;

        public int playerItemPoints = 0;         
        public static GameManager instance = null;

        public BoardManager bm;

        // This will hold the current Level Script.
        public Level levelScript;       
        public int level = 1;
        public static int playerPoints = 0;
        public static int antiPlayerPoints = 0;

        private static bool levelOver = false;

        //Awake is always called before any Start functions
        void Awake()
        {
            //Check if instance already exists
            if (instance == null)

                //if not, set instance to this
                instance = this;

            //If instance already exists and it's not this:
            else if (instance != this)

                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);

            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
            
            //Get a component reference to the attached BoardManager script
            bm = GetComponent<BoardManager>();

            //Call the InitGame function to initialize the first level 
            InitGame();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static public void CallbackInitialization()
        {
            //register the callback to be called everytime the scene is loaded
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        //This is called each time a scene is loaded.
        static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            instance.level++;
            instance.InitGame();
            levelOver = false;
        }

        //Initializes the game for each level.
        void InitGame()
        {
            Debug.Log("level is :: " + level);
            // Initializes the appropriate LevelScript
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

        //public void SetLevelOver(bool state)
        //{
        //    levelOver = state;
        //}
    }
}
