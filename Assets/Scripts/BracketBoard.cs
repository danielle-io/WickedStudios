using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace WickedStudios

{
    public class BracketBoard : MonoBehaviour
    {
        public int columns = 9;
        public int rows = 9;
        GameManager gm = new GameManager();
        private Transform boardHolder;
        public GameObject faller;

        //A variable to store a reference to the transform of our Board object.
        private static List<Vector3> gridPositions = new List<Vector3>();

        //Reset our list of gridpositions.
        void InitialiseList()
        {
            //Clear our list gridPositions.
            gridPositions.Clear();

            //Loop through x axis (columns).
            for (int x = 1; x < columns - 1; x++)
            {
                //Within each column, loop through y axis (rows).
                for (int y = 1; y < rows - 1; y++)
                {
                    //At each index add a new Vector3 to our list with the x and y coordinates of that position.
                    gridPositions.Add(new Vector3(x, y, 0f));
                }
            }
        }


        // SetupScene initializes our level and 
        // calls the previous functions to lay out the game board
        public void SetupScene(int level)
        {
            LevelTwo lvlTwo = new LevelTwo();
            LevelThree lvlThree = new LevelThree();

            switch (level)
            {
                case 2:
                    //LevelTwoBoardSetup();
                    InitialiseList();
                    lvlTwo.LevelTwoSetup(faller);
                    break;
                case 3:
                    //LevelThreeBoardSetup();
                    InitialiseList();
                    lvlThree.LevelThreeSetup();
                    break;
                default:
                    Debug.Log("default switch statement");
                    break;
            }
        }
    }
}
