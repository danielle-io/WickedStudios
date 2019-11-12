using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic; 		
using Random = UnityEngine.Random; 		

namespace WickedStudios
	
{
	public class BoardManager : MonoBehaviour
	{

        public int columns = 9;
        public int rows = 9;
        private Transform boardHolder;
        public GameObject boss;
        public GameObject player;
        public GameObject plant;
        public GameObject coworker;
        public GameObject paper;
        public GameObject[] desks;
        public GameObject outerWallTiles;
        public GameObject floorTiles;



        //A variable to store a reference to the transform of our Board object.
        private static List<Vector3> gridPositions = new List<Vector3>();

        //Reset our list of gridpositions.
        void InitialiseList ()
		{
			//Clear our list gridPositions.
			gridPositions.Clear ();
            
            //Loop through x axis (columns).
            for (int x = 1; x < columns-1; x++)
			{
				//Within each column, loop through y axis (rows).
				for(int y = 1; y < rows-1; y++)
				{
					//At each index add a new Vector3 to our list with the x and y coordinates of that position.
					gridPositions.Add (new Vector3(x, y, 0f));
                }
			}
		}
		
		public Vector3 GetRandomPosition(GameObject item)
		{
            Debug.Log("In get random position");
            int randomIndex = Random.Range (0, gridPositions.Count);
            Vector3 randomPosition = gridPositions[randomIndex];

            gridPositions.RemoveAt(randomIndex);

            // Removing some space around the object so they
            // aren't too close together
            int extraSpacePerItem = GetRandomSpacePerItem(item);
            RemoveNearbyGrids(randomIndex, extraSpacePerItem);

            return randomPosition;
		}

        public void AddObjectToBoardAtPosition(GameObject item, Vector3 position)
        {

            Instantiate(item, position, Quaternion.identity);
        }


        public void RemoveNearbyGrids(int position, int extraSpacePerItem)
        {
            try
            {
                gridPositions.RemoveAt(position + extraSpacePerItem);
                gridPositions.RemoveAt(position - extraSpacePerItem);
            }

            catch (Exception)
            {
                Debug.Log("in the catch for gridPosition setting");
            }
        }


        public int ChooseRandomNumInRange(int minimum, int maximum)
		{
            return Random.Range(minimum, maximum + 1);
        }


        public int GetRandomSpacePerItem(GameObject item)
        {
            Debug.Log("item is " + item.transform.tag);
            String itemName = item.transform.tag;
            switch (itemName)
            {
                case "Paper":
                    return 2;
                case "Coworker":
                    return 1;
                case "Desk":
                    return 2;
                case "Player":
                    return 3;
                default:
                    return 2;
            }
        }

        // Creates the outer walls and floor.
        void BoardSetup()
        {

            //Instantiate Board and set boardHolder to its transform.
            boardHolder = new GameObject("Board").transform;

            // Loop along x axis, starting from -1 (to fill corner) with floor or 
            // outerwall edge tiles.
            for (int x = -1; x < columns + 1; x++)
            {
                //Loop along y axis, starting from -1 to place floor or outerwall tiles.
                for (int y = -1; y < rows + 1; y++)
                {
                    GameObject toInstantiate = floorTiles;


                    if (x == -1 || x == columns || y == -1 || y == rows)
                        toInstantiate = outerWallTiles;

                    GameObject instance = Instantiate
                        (toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                    // Set the parent of our newly instantiated 
                    // object instance to boardHolder, this is just 
                    // organizational to avoid cluttering hierarchy.
                    instance.transform.SetParent(boardHolder);
                }
            }
        }

        // SetupScene initializes our level and 
        // calls the previous functions to lay out the game board
        public void SetupScene (int level, Level levelScript)
		{
            switch (level)
            {
                case 1:
                    Debug.Log("In case one of setup scene in bm");
                    BoardSetup();
                    //lvlOne.BoardSetup(rows, columns);
                    InitialiseList();
                    levelScript.CheckLevelOver();
                    levelScript.SetupLevel(this);
                    break;
                // case 2:
                //     lvlTwo.BoardSetup(rows, columns);
                //     InitialiseList();
                //     lvlTwo.LevelTwoSetup();
                //     break;
                // case 3:
                //     lvlThree.BoardSetup(rows, columns);
                //     InitialiseList();
                //     lvlThree.LevelThreeSetup();
                //     break;
                default:
                    Debug.Log("default switch statement");
                    break;
            }
        }
    }
}
