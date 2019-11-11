using UnityEngine;
using System;
using System.Collections;
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

        public int columns = 9;
        public int rows = 9;

        public GameObject boss;
        public GameObject player;
        public GameObject outerWallTiles;
        public GameObject floorTiles;
        public GameObject plant;
        public GameObject coworker;
		public GameObject[] desks;									
        public GameObject papers;
        public static ArrayList allItemPositions = new ArrayList();

        //A variable to store a reference to the transform of our Board object.
        private Transform boardHolder;

        //A list of possible locations to place tiles.			
        private static List <Vector3> gridPositions = new List <Vector3> ();	
		
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
		
		void BoardSetup ()
		{
			//Instantiate Board and set boardHolder to its transform.
			boardHolder = new GameObject("Board").transform;
			
			// Loop along x axis, starting from -1 (to fill corner) with floor or 
            // outerwall edge tiles.
			for(int x = -1; x < columns + 1; x++)
			{
				//Loop along y axis, starting from -1 to place floor or outerwall tiles.
				for(int y = -1; y < rows + 1; y++)
				{
					GameObject toInstantiate = floorTiles;
					
			
					if(x == -1 || x == columns || y == -1 || y == rows)
						toInstantiate = outerWallTiles;

					GameObject instance = Instantiate 
                        (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
					
					// Set the parent of our newly instantiated 
                    // object instance to boardHolder, this is just 
                    // organizational to avoid cluttering hierarchy.
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

            int count = 0;
            // To prevent overlap of random items
            while (allItemPositions.Contains(randomPosition) && count != 3){
                randomPosition = gridPositions[randomIndex];
                count += 1;
            }

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
		
	    public int ChooseGameObjectsFromArrAtRandom (int minimum, int maximum)
		{
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

        public Vector3 PlaceGameObjectAtRandom(GameObject item)
        {
            int extraSpacePerItem = GetRandomSpacePerItem(item);

            // Choose a position for randomPosition by 
            // getting a random position from our list of available 
            // Vector3s stored in gridPosition
            Vector3 randomPosition = RandomPosition(extraSpacePerItem);

            Instantiate(item, randomPosition, Quaternion.identity);
            return randomPosition;
        }

        public ArrayList GetOccupiedPositions()
        {
            return allItemPositions;
        }

        public void SetOccupiedPositions(Vector3 currentItem)
        {
            allItemPositions.Add(currentItem);
        }

        public int GetRandomSpacePerItem(GameObject item)
        {
            Debug.Log("item is " + item.transform.tag);
            String itemName = item.transform.name;
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

        public void GetLevelSetupScript(int level)
        {
            LevelOne LvlOne = new LevelOne();
            LevelTwo LvlTwo = new LevelTwo();
            LevelThree LvlThree = new LevelThree();

            switch (level)
            {
                case 1:
                    LvlOne.LevelOneSetup(player, 
                        papers, desks, coworker, boss, plant);
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
