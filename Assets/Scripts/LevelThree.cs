using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    public class LevelThree : Level
    {

        BoardManager BM = new BoardManager();

        public void LevelThreeSetup()
        {

        }

        public void BoardSetup(int rows, int columns)
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
        public override void SetupLevel(BoardManager bm)
        {
        }

        public override bool CheckLevelOver()
        {
            return false;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

