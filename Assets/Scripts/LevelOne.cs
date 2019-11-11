using UnityEngine;

namespace WickedStudios
{
    public class LevelOne : MonoBehaviour
    {
        private Transform boardHolder;
        public static int paperObjectTotal;
        //public static int paperObjectsLeft;
        BoardManager bm = new BoardManager();
        GameManager gm = new GameManager();

        public void LevelOneSetup(GameObject player, GameObject paper,
            GameObject[] desks, GameObject coworker,
            GameObject boss, GameObject plant)
        {
            AddCharacters(coworker, boss, player);
            AddSetPositionObjects(desks, plant);
            AddRandomPositionObjects(paper);
        }

        private void AddSetPositionObjects(
            GameObject[] desks, GameObject plant)
        {
            // A set array of desk positions (for now at least)
            Vector3[] deskPositions = { new Vector3(1, 5, 0),
                new Vector3(4, 5, 0), new Vector3(7, 5, 0)};

            // Hard coding desk positions (for now at least)
            for (int i = 0; i < 3; i++)
            {
                bm.AddObjectToBoardAtPosition(desks[0], deskPositions[i]);
            }

            // Plant placement
            bm.AddObjectToBoardAtPosition(plant, new Vector3(0, 7.6f, 0));
        }

        public void AddCharacters(GameObject coworker,
            GameObject boss, GameObject player)
        {
            // Add single coworker (for now at least)
            Vector3 coworkerPosition = new Vector3();
            coworkerPosition = bm.GetRandomPosition(coworker);
            bm.AddObjectToBoardAtPosition(coworker, coworkerPosition);

            // Add player
            Vector3 playerPosition = new Vector3();
            playerPosition = bm.GetRandomPosition(player);
            bm.AddObjectToBoardAtPosition(player, playerPosition);

            // Add boss to set position
            bm.AddObjectToBoardAtPosition(boss, new Vector3(7, 7, 0));
        }

        public void AddRandomPositionObjects(GameObject paper)
        {
            // Paper: get random count, set total paper, set each paper
            paperObjectTotal = bm.ChooseRandomNumInRange(8, 10);

            //paperObjectsLeft = paperObjectTotal;

            for (int i = 0; i < paperObjectTotal; i++)
            {
                Vector3 paperPosition = new Vector3();
                paperPosition = bm.GetRandomPosition(paper);
                bm.AddObjectToBoardAtPosition(paper, paperPosition);
            }
         }

        //public void LowerPaperObjectsLeft()
        //{
        //    paperObjectsLeft -= 1;
        //    Debug.Log("paper removed from paperObjectsLeft:: " + paperObjectsLeft);
        //}

        // Creates the outer walls and floor.
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
                    GameObject toInstantiate = bm.floorTiles;


                    if (x == -1 || x == columns || y == -1 || y == rows)
                        toInstantiate = bm.outerWallTiles;

                    GameObject instance = Instantiate
                        (toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                    // Set the parent of our newly instantiated 
                    // object instance to boardHolder, this is just 
                    // organizational to avoid cluttering hierarchy.
                    instance.transform.SetParent(boardHolder);
                }
            }
        }

            public int GetPaperObjectsLeft()
        {
            GameObject[] paper = GameObject.FindGameObjectsWithTag("Paper");
            return paper.Length;
        }

        public bool CheckLevelOver()
        {
            return (GetPaperObjectsLeft() == 0);
        }
    }
}

