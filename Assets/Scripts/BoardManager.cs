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
        public int textRow = 8;

        //private GameObject[] text;

        void Awake()
        {
            inst = this;
        }

        public void InitialiseList (int rows, int columns)
		{
			gridPositions.Clear();

            // Right now the leftmost x within the office is -1 for some reason. Most likely due to enlarging the camera.
            for (int x = -1; x < columns -1; x++)
			{
                // We want the y position to go only up to the row with the text.
				for(int y = 0; y < textRow; y++)
				{
					gridPositions.Add(new Vector3(x, y, 0f));
                }
			}
        }

        public Vector3 GetRandomPosition()
		{
            int randomIndex = Random.Range (0, gridPositions.Count - 1);
            Vector3 randomPosition = new Vector3(-10,-10,-10);
            try
            {
                randomPosition = gridPositions[randomIndex];
            }
            catch (Exception)
            {
                Debug.Log("RandomPosition index out of range");
            }
            return randomPosition;
		}

        public void AddObjectToBoardAtPosition(GameObject item, Vector3 position)
        {
            Instantiate(item, position, Quaternion.identity);
            gridPositions.Remove(position);

            float extraSpacePerItem = GetExtraSpacePerItem(item);
            RemoveNearbyGrids(position, extraSpacePerItem);
        }
        public void RemoveNearbyGrids(Vector3 position, float extraSpacePerItem)
        {
            float x = position[0];
            float y = position[1];
            Vector3 removePosition;
            while (extraSpacePerItem >= 0)
            {
                // Remove Up
                removePosition = new Vector3(x, y + extraSpacePerItem);
                try
                    {
                        gridPositions.Remove(removePosition);
                    }
                catch (Exception)
                    {
                        Debug.Log("Remove space failed");
                    }

                // Remove Left
                removePosition = new Vector3(x - extraSpacePerItem, y);
                try
                    {
                        gridPositions.Remove(removePosition);
                    }
                catch (Exception)
                    {
                        Debug.Log("Remove space failed");
                    }

                // Remove UpLeft
                removePosition = new Vector3(x - extraSpacePerItem, y + extraSpacePerItem);
                try
                    {
                        gridPositions.Remove(removePosition);
                    }
                catch (Exception)
                    {
                        Debug.Log("Remove space failed");
                    }

                // Remove Right    
                removePosition = new Vector3(x + extraSpacePerItem, y);
                try
                    {
                        gridPositions.Remove(removePosition);
                    }
                catch (Exception)
                    {
                        Debug.Log("Remove space failed");
                    }

                // Remove UpRight    
                removePosition = new Vector3(x + extraSpacePerItem, y + extraSpacePerItem);
                try
                    {
                        gridPositions.Remove(removePosition);
                    }
                catch (Exception)
                    {
                        Debug.Log("Remove space failed");
                    }
                --extraSpacePerItem;  
            }
        }        

        public int ChooseRandomNumInRange(int minimum, int maximum)
		{
            return Random.Range(minimum, maximum + 1);
        }

        public float GetExtraSpacePerItem(GameObject item)
        {
            Debug.Log("item is " + item.transform.name);
            switch (item.transform.name)
            {
                case "Paper":
                    return 1;
                case "Coworker":
                    return 2;
                case "Desk":
                    return 2;
                case "Player":
                    return 2;
                case "Bookcase":
                    return 2;
                default:
                    return 2;
            }
        }

        public void BoardSetup(int rows, int columns, GameObject carpet)
        {
            Transform boardHolder;

            // Instantiate Board and set boardHolder to its transform.
            boardHolder = new GameObject("Board").transform;

            for (int x = -1; x < columns + 1; x++)
            {
                for (int y = -1; y < rows + 1; y++)
                {
                    GameObject toInstantiate = carpet;
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

        public bool isValidPosition(Vector3 position)
        {
            // This is a hack and I'm basically saying as long as the x coordinate is above -1 its valid.
            return position[0] > -1;
        }
    }
}
