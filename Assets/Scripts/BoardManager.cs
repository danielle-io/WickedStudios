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

        private GameObject[] text;

        void Awake()
        {
            inst = this;
        }

        public void InitialiseList (int rows, int columns)
		{
			gridPositions.Clear();

            for (int x = 1; x < columns -1; x++)
			{
				for(int y = 1; y < rows -1; y++)
				{
					gridPositions.Add(new Vector3(x, y, 0f));
                }
			}

            // Remove the text area from grid positions
            //gridPositions.RemoveAt(randomIndex);
            text = GameObject.FindGameObjectsWithTag("Text");
            foreach (GameObject item in text)
            {
                Vector3 position = new Vector3();
                position = item.transform.position;

                // Figure out how grid points are an int and not a Vector3
                gridPositions.Remove(position);
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
            Vector3 position = new Vector3();
            position = gridPositions[randomIndex];
            RemoveNearbyGrids(position, extraSpacePerItem);


            return randomPosition;
		}

        public void AddObjectToBoardAtPosition(GameObject item, Vector3 position)
        {
            Instantiate(item, position, Quaternion.identity);
        }


        public void RemoveNearbyGrids(Vector3 position, int extraSpacePerItem)
        {
            // Fix this later so we actually use extraSpacePerItem in a while loop
            try
            {
                Vector3 newPositions = new Vector3();
                float one = position[0];
                float two = position[1];

                newPositions = new Vector3(one -1, two-1, 0f);
                gridPositions.Remove(newPositions);
                newPositions = new Vector3(one + 1, two + 1, 0f);
                gridPositions.Remove(newPositions);
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
            //Debug.Log("item is " + item.transform.tag);
            //string itemName = item.transform.tag;
            switch (item.transform.tag)
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
        public void BoardSetup(int rows, int columns, GameObject border, GameObject carpet)
        {
            Transform boardHolder;

            // Instantiate Board and set boardHolder to its transform.
            boardHolder = new GameObject("Board").transform;

            for (int x = -1; x < columns + 1; x++)
            {
                for (int y = -1; y < rows + 1; y++)
                {
                    GameObject toInstantiate = carpet;
                    //if (x == -1 || x == columns || y == -1 || y == rows)
                        //toInstantiate = border;
                    GameObject instance = Instantiate
                        (toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
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
