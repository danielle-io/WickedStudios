using UnityEngine;
using System;
using System.Collections.Generic; 		
using Random = UnityEngine.Random; 		

namespace WickedStudios
{
	public class BoardManager : MonoBehaviour 
	{
        private static List<Vector3> gridPositions = new List<Vector3>();
        public static BoardManager inst;
        //public Level levelscript;

        void Awake()
        {
            inst = this;
        }

        public void InitialiseList (int rows, int columns)
		{
			gridPositions.Clear ();
            
            for (int x = 1; x < columns-1; x++)
			{
				for(int y = 1; y < rows-1; y++)
				{
					gridPositions.Add (new Vector3(x, y, 0f));
                }
			}
		}
		
		public Vector3 GetRandomPosition(GameObject item)
		{
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
                    return 3;
                case "Desk":
                    return 3;
                case "Player":
                    return 3;
                default:
                    return 2;
            }
        }

        // Creates the outer walls and floor.
        public void BoardSetup(int rows, int columns, GameObject border, GameObject floor)
        {

            Transform boardHolder;

            // Instantiate Board and set boardHolder to its transform.
            boardHolder = new GameObject("Board").transform;

            // Loop along x axis, starting from -1 (to fill corner) with floor or 
            // outerwall edge tiles.
            for (int x = -1; x < columns + 1; x++)
            {
                //Loop along y axis, starting from -1 to place floor or outerwall tiles.
                for (int y = -1; y < rows + 1; y++)
                {
                    GameObject toInstantiate = floor;


                    if (x == -1 || x == columns || y == -1 || y == rows)
                        toInstantiate = border;

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
        public void SetupScene (Level levelScript)
		{
            levelScript.SetupLevel(this);

        }
    }
}
