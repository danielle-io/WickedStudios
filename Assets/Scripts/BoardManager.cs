using UnityEngine;
using System;
using System.Collections.Generic; 		
using Random = UnityEngine.Random; 		

namespace WickedStudios
	
{
	public class BoardManager : MonoBehaviour
	{
		// Using Serializable allows us to embed a class 
        // with sub properties in the inspector
		[Serializable]

		public class Count
		{
			public int minimum; 			
			public int maximum; 			
			
			//Assignment constructor.
			public Count (int min, int max)
			{
				minimum = min;
				maximum = max;
			}
		}

        public int columns = 10;
        public int rows = 10;
        	
        public GameObject boss;
        public GameObject[] coworkers;
        public GameObject[] floorTiles;									
		public GameObject[] desks;									
		public GameObject[] outerWallTiles;
        public GameObject[] papers;

        //A variable to store a reference to the transform of our Board object.
        private Transform boardHolder;

        //A list of possible locations to place tiles.			
        private static List <Vector3> gridPositions = new List <Vector3> ();	
		
		void InitialiseList ()
		{
			//Clear our list gridPositions.
			gridPositions.Clear ();

            Debug.Log("columns:: " + columns + " rows:: " + rows);

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
		
		//Sets up the outer walls and floor (background) of the game board.
		void BoardSetup ()
		{
			//Instantiate Board and set boardHolder to its transform.
			boardHolder = new GameObject ("Board").transform;
			
			//Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
			for(int x = -1; x < columns + 1; x++)
			{
				//Loop along y axis, starting from -1 to place floor or outerwall tiles.
				for(int y = -1; y < rows + 1; y++)
				{
					//Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
					GameObject toInstantiate = floorTiles[Random.Range (0,floorTiles.Length)];
					
					//Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
					if(x == -1 || x == columns || y == -1 || y == rows)
						toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
					
					//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
					GameObject instance =
						Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					
					//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
					instance.transform.SetParent (boardHolder);
				}
			}
		}
		
		//RandomPosition returns a random position from our list gridPositions.
		Vector3 RandomPosition(int extraSpacePerItem)
		{
            int randomIndex = Random.Range (0, gridPositions.Count);

            // set the vector's value to the entry at 
            // randomIndex from our List gridPositions.
            Vector3 randomPosition = gridPositions[randomIndex];
			
			//Remove the entry at randomIndex from the list so that it can't be re-used.
			gridPositions.RemoveAt (randomIndex);

            // I added the + 1 so the items aren't too close to each other
            // until I figure out a better way - D
            try
            {
                gridPositions.RemoveAt(randomIndex + extraSpacePerItem);
                gridPositions.RemoveAt(randomIndex - extraSpacePerItem);
            }

            catch(Exception)
            {
                Debug.Log("in the catch for gridPosition setting");
            }

            //Return the randomly selected Vector3 position.
            return randomPosition;
		}
		
	    public int  ChooseGameObjectsFromArrAtRandom (GameObject[] itemArr, int minimum, int maximum)
		{


            //Choose a random number of objects to instantiate within the minimum and maximum limits
            return Random.Range(minimum, maximum + 1);
        }

        public void PlaceArrOfGameObjectsAtRandom(GameObject[] itemArr, int objectCount)
        {
            //Instantiate objects until the randomly chosen limit objectCount is reached
            for (int i = 0; i < objectCount; i++)
            {
                PlaceGameObjectAtRandom(itemArr[0]);
            }
        }

        public void PlaceGameObjectAtRandom(GameObject item)
        {

            int extraSpacePerItem = GetRandomSpacePerItem(item);

            //Choose a position for randomPosition by getting a random position from our list of available Vector3s stored in gridPosition
            Vector3 randomPosition = RandomPosition(extraSpacePerItem);

            //Instantiate tileChoice at the position returned by RandomPosition with no change in rotation
            Instantiate(item, randomPosition, Quaternion.identity);
        }

        public int GetRandomSpacePerItem(GameObject item)
        {
            Debug.Log("item is " + item + item.transform.name);

            String itemName = item.transform.name.Substring(0, item.transform.name.Length - 1);
            switch (itemName)
            {

                case "Paper":
                    Debug.Log("made it in papers");
                    return 2;
                //case "coworkers":
                //    return 1;
                //    break;
                case "Desk":
                    return 2;
                default:
                    return 1;
            }

        }

        public void GetLevelSetupScript(int level)
        {
            LevelOne LvlOne = new LevelOne();
            LevelTwo LvlTwo = new LevelTwo();
            LevelThree LvlThree = new LevelThree();

            switch (level)
            {
                case 1:
                    LvlOne.LevelOneSetup(papers, desks, coworkers);
                    break;
                case 2:
                    LvlTwo.LevelTwoSetup();
                    break;
                case 3:
                    LvlThree.LevelThreeSetup();
                    break;
                default:
                    Debug.Log("default switch statement");
                    break;
            }
        }

        // SetupScene initializes our level and 
        // calls the previous functions to lay out the game board
        public void SetupScene (int level)
		{
			//Creates the outer walls and floor.
			BoardSetup();
			
			//Reset our list of gridpositions.
			InitialiseList();

            GetLevelSetupScript(level);
        }
    }
}
