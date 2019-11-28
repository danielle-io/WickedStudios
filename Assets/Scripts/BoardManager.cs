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
            // by taking out any grid position with its Y value

            // Giving up on doing this the right way for now
            // bc i cant seem to get the X and Y from a 
            // RectTransform :( harcoding a 7 Y value bc
            // that's where the text is rn
            text = GameObject.FindGameObjectsWithTag("Text");

            foreach (GameObject item in text)
            {
                //RectTransform rt;
                //Vector3 position = new Vector3();
                //rt = item.GetComponent<RectTransform>();

                for (int i = 0; i < gridPositions.Count; i++)
                {
                    Vector3 checking = gridPositions[i];
                    //Debug.Log("position other y is " + (int)checking[1]);
                    //int difference = (int)position[1] - (int)checking[1];

                    float difference = 8.0f - checking[1];
                    if (difference <= 1)
                    {
                        //Debug.Log("removing from grid at y value " + (int)checking[1]);
                        gridPositions.Remove(checking);
                    }
                }
            }
        }

        public Vector3 GetRandomPosition()
		{
            int randomIndex = Random.Range (0, gridPositions.Count - 1);
            Vector3 randomPosition = gridPositions[randomIndex];
            return randomPosition;
		}

        public void AddObjectToBoardAtPosition(GameObject item, Vector3 position)
        {
            Instantiate(item, position, Quaternion.identity);
            gridPositions.Remove(position);

            int extraSpacePerItem = GetExtraSpacePerItem(item);
            RemoveNearbyGrids(position, extraSpacePerItem);
        }


        public void RemoveNearbyGrids(Vector3 position, int extraSpacePerItem)
        {
            float x = position[0];
            float y = position[1];
            switch(extraSpacePerItem)
            {
                case 3:
                    Debug.Log("Removing space above...");
                    Vector3 up = new Vector3(x, y-1);
                    try
                    {
                        gridPositions.Remove(up);
                    }
                    catch (Exception)
                    {
                        Debug.Log("Remove space failed");
                    }
                    goto case 2;
                case 2:
                    Debug.Log("Removing space left...");
                    Vector3 left = new Vector3(x-1, y);
                    try
                    {
                        gridPositions.Remove(left);
                    }
                    catch (Exception)
                    {
                        Debug.Log("Remove space failed");
                    }
                    goto case 1;
                case 1:
                    Debug.Log("Removing space right...");
                    Vector3 right = new Vector3(x+1, y);
                    try
                    {
                        gridPositions.Remove(right);
                    }
                    catch (Exception)
                    {
                        Debug.Log("Remove space failed");
                    }
                    break;
                default:
                    break;
            }

            // while (extraSpacePerItem > 0)
            // {
            //     Debug.Log("removing space ");
            //     Vector3 newPositions = new Vector3();

            //     float one = position[0];
            //     float two = position[1];

            //     newPositions = new Vector3(one - extraSpacePerItem, two - extraSpacePerItem, 0f);

            //     try
            //     {
            //         gridPositions.Remove(newPositions);
            //     }
            //     catch (Exception)
            //     {
            //         Debug.Log("in the catch for gridPosition setting");
            //     }
            //     newPositions = new Vector3(one + extraSpacePerItem, two + extraSpacePerItem, 0f);

            //     try
            //     {
            //         gridPositions.Remove(newPositions);
            //     }
            //     catch (Exception)
            //     {
            //         Debug.Log("in the catch for gridPosition setting");
            //     }
            //     extraSpacePerItem -= 1;
            // }
        }        

        public int ChooseRandomNumInRange(int minimum, int maximum)
		{
            return Random.Range(minimum, maximum + 1);
        }

        public int GetExtraSpacePerItem(GameObject item)
        {
            Debug.Log("item is " + item.transform.name);
            switch (item.transform.name)
            {
                case "Paper":
                    return 2;
                case "Coworker":
                    return 3;
                case "Desk":
                    return 2;
                case "Player":
                    return 3;
                case "Bookcase":
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
