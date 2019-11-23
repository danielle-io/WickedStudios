using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace WickedStudios
{                  
    public class GameManager : MonoBehaviour
    {
        public float levelStartDelay = 2f;

        //Delay between each Player turn.
        //public float turnDelay = 0.1f;

        public static GameManager instance = null;

        public Level levelScript;
        private int level;

        private static int playerPoints = 0;
        private static int antiPlayerPoints = 0;

        BoardManager bm;

        void Awake()
        {
            instance = this;

            //if (instance == null)
            //{
            //    instance = this;
            //}

            //// If instance already exists and it's not this:
            //else if (instance != this)
            //{
            //    Destroy(gameObject);
            //}

            // Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);

            //Get a component reference to the attached BoardManager script
            bm = GetComponent<BoardManager>();
            GetActiveScene();
            InitGame();
        }
   
        private void GetActiveScene()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            string sceneName = activeScene.name;
            switch (sceneName)
            {
                case "Level1":
                    level = 1;
                    break;
                case "Level2":
                    level = 2;
                    break;
                case "Level3":
                    level = 3;
                    break;
                default:
                    Debug.Log("default LEVEL statement");
                    level = 1;
                    break;
            }
        }

        // Initializes the game for each level.
        public void InitGame()
        {
            switch (level)
            {
                case 1:
                    levelScript = GetComponent<LevelOne>();
                    break;
                case 2:
                    Debug.Log("LEVEL SCRIPT 2");
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
            bm = GetComponent<BoardManager>();
            bm.SetupScene(levelScript);
        }

        void Update()
        {
            if (levelScript.CheckLevelOver() == -1){
                Debug.Log("LEVEL IS OVER");
                SceneManager.LoadScene("GameOver");
            }
            if (levelScript.CheckLevelOver() == 1)
            {
                Debug.Log("player won!");
                string nextScene = levelScript.GetNextScene();
                SceneManager.LoadScene(nextScene);
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
            Debug.Log("PLAYER POINTS = " + playerPoints);
        }

        public int GetPlayerPoints()
        {
            return playerPoints;
        }

        public void SetAntiPlayerPoints(int points)
        {
            antiPlayerPoints += points;
            Debug.Log("COWORKER POINTS = " + antiPlayerPoints);
        }

        public int GetAntiPlayerPoints()
        {
            return antiPlayerPoints;
        }
    }
}
