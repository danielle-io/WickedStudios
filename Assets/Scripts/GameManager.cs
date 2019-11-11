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

        private BoardManager bm;       
        public int level = 1;
        
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
        }

        //Initializes the game for each level.
        void InitGame()
        {
            Debug.Log("level is :: " + level);
            bm.SetupScene(level);
        }

        //Update is called every frame.
        void Update()
        {
            if (GetEndConditionByLevel(level)){
                Debug.Log("LEVEL IS OVER");
            }
        }

        public bool GetEndConditionByLevel(int level)
        {
            LevelOne LvlOne = new LevelOne();
            LevelTwo LvlTwo = new LevelTwo();
            LevelThree LvlThree = new LevelThree();

            switch (level)
            {
                case 1:
                    return LvlOne.CheckLevelOver();
                case 2:
                    return LvlTwo.CheckLevelOver();
                case 3:
                    return LvlThree.CheckLevelOver();
                default:
                    Debug.Log("default switch statement");
                    return true;
            }
        }

        public int GetLevel()
        {
            return level;
        }
    }
}
