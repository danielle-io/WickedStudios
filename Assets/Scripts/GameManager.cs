﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace WickedStudios
{
    using System.Collections.Generic;       
    using UnityEngine.UI;                   

    public class GameManager : MonoBehaviour
    {
        //Time to wait before starting level, in seconds.
        public float levelStartDelay = 2f;

        //Delay between each Player turn.
        public float turnDelay = 0.1f;

        public int playerItemPoints = 0;

        //Static instance of GameManager which allows 
        //it to be accessed by any other script.            
        public static GameManager instance = null;

        //Boolean to check if it's players turn, hidden in inspector but public.        
        [HideInInspector] public bool playersTurn = true;
        
        private Text levelText;                                
        private GameObject levelImage;                          
        private BoardManager bm;       
        public int level = 1;

        //List of all Enemy units, used to issue them move commands.                                
        private List<Coworker> coworkers;
        private bool coworkersMoving;

        // Boolean to check if we're setting up board, 
        // prevent Player from moving during setup.                          
        //private bool doingSetup = true;                         

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

            //Assign coworkers to a new List of Enemy objects.
            coworkers = new List<Coworker>();

            //Get a component reference to the attached BoardManager script
            bm = GetComponent<BoardManager>();

            //Call the InitGame function to initialize the first level 
            InitGame();
        }

        // this is called only once, and the paramter 
        // telsl it to be called only after the scene was loaded
        //(otherwise, our Scene Load callback would be called the very 
        // first load, and we don't want that)
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
            //While doingSetup is true the player can't move, prevent player from moving while title card is up.
            //doingSetup = true;

            //Get a reference to our image LevelImage by finding it by name.
            //levelImage = GameObject.Find("LevelImage");

            //Set levelImage to active blocking player's view of the game board during setup.
            //levelImage.SetActive(true);

            //Call the HideLevelImage function with a delay in seconds of levelStartDelay.
            //Invoke("HideLevelImage", levelStartDelay);

            //Clear any Enemy objects in our List to prepare for next level.
            //coworkers.Clear();

            //Call the SetupScene function of the BoardManager script, pass it current level number.
            bm.SetupScene(level);
        }


        //Hides black image used between levels
        //void HideLevelImage()
        //{
        //    //Disable the levelImage gameObject.
        //    levelImage.SetActive(false);

        //    //Set doingSetup to false allowing player to move again.
        //    doingSetup = false;
        //}

        //Update is called every frame.
        void Update()
        {

            if (GetEndConditionByLevel(level)){
                Debug.Log("LEVEL IS OVER");
            }

            //Check that playersTurn or enemiesMoving or doingSetup are not currently true.
            if (playersTurn)

                //If any of these are true, return and do not start moveCoworkers.
                return;

            // Don't delete this yet, it breaks the code
            //StartCoroutine(MoveCoworkers());
            Debug.Log("on update yall");

            switch (level)
            {
                case 1:
                    Coworker coworker = new Coworker();
                    coworker.MoveCoworkers();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Debug.Log("default switch statement");
                    break;
            }
        }

        // Depending on the level, we will call the correct
        // check level over condition to find out if game has ended
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

        //Call this to add the passed in Enemy to the List of Enemy objects.
        //public void AddEnemyToList(Coworker script)
        //{
        //    //Add Enemy to List coworkers.
        //    coworkers.Add(script);
        //}


        //GameOver is called when the player reaches 0 food points
        public void GameOver()
        {
            //Set levelText to display number of levels passed and game over message
            //levelText.text = "After " + level + " days, you starved.";

            //Enable black background image gameObject.
            levelImage.SetActive(true);

            //Disable this GameManager.
            enabled = false;
        }

        public int GetLevel()
        {
            return level;
        }

        //Coroutine to move coworkers in sequence.
        //IEnumerator MoveCoworkers()
        //{
        //    //While enemiesMoving is true player is unable to move.
        //    coworkersMoving = true;

        //    //Wait for turnDelay seconds, defaults to .1 (100 ms).
        //    yield return new WaitForSeconds(turnDelay);

        //    ////If there are no coworkers spawned (IE in first level):
        //    //if (coworkers.Count == 0)
        //    //{
        //    //    //Wait for turnDelay seconds between moves, replaces delay caused by enemies moving when there are none.
        //    //    yield return new WaitForSeconds(turnDelay);
        //    //}

        //    //Loop through List of Enemy objects.
        //    for (int i = 0; i < coworkers.Count; i++)
        //    {
        //        //Call the MoveCoworker function of coworker at index i in the enemies List.
        //        //coworkers[i].MoveCoworkers();

        //        //Wait for Enemy's moveTime before moving next Enemy, 
        //        yield return new WaitForSeconds(coworkers[i].moveTime);
        //    }
        //    //Once coworkers are done moving, set playersTurn to true so player can move.
        //    playersTurn = true;

        //    //Enemies are done moving, set enemiesMoving to false.
        //    coworkersMoving = false;
        //}

    }
}
