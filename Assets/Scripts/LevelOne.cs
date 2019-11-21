using UnityEngine;

namespace WickedStudios
{
    // LevelOne inherits from Level, our base class for levels.
    public class LevelOne : Level
    {
        public int columns = 9;
        public int rows = 9;
        public GameObject boss;
        public GameObject player;
        public GameObject plant;
        public GameObject coworker;
        public GameObject paper;
        public GameObject[] desks;
        public GameObject outerWallTiles;
        public GameObject floorTiles;

        public static int paperObjectTotal;
        
        private void Update()
        {
            CheckLevelOver();
        }

        // Overrides the base class SetupLevel.
        public override void SetupLevel(BoardManager bm)
        {
            bm.BoardSetup(rows, columns, outerWallTiles, floorTiles);
            bm. InitialiseList(rows, columns);
            AddCharacters();
            AddSetPositionObjects();
            AddRandomPositionObjects();
        }

        private void AddSetPositionObjects()
        {
            BoardManager bm = gameObject.GetComponent<BoardManager>();

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

        private void AddCharacters()
        {
            // Add single coworker (for now at least)
            Vector3 coworkerPosition = BoardManager.inst.GetRandomPosition(coworker);
            BoardManager.inst.AddObjectToBoardAtPosition(coworker, coworkerPosition);

            // Add player
            Vector3 playerPosition = BoardManager.inst.GetRandomPosition(player);
            BoardManager.inst.AddObjectToBoardAtPosition(player, playerPosition);

            // Add boss to set position
            BoardManager.inst.AddObjectToBoardAtPosition(boss, new Vector3(7, 7, 0));
        }

        public void AddRandomPositionObjects()
        {
            BoardManager bm = gameObject.GetComponent<BoardManager>();

            // Paper: get random count, set total paper, set each paper
            paperObjectTotal = BoardManager.inst.ChooseRandomNumInRange(8, 10);
            
            for (int i = 0; i < paperObjectTotal; i++)
            {
                Vector3 paperPosition = bm.GetRandomPosition(paper);
                bm.AddObjectToBoardAtPosition(paper, paperPosition);
            }
         }
         
         public int GetPaperObjectsLeft()
        {
            GameObject[] papers = GameObject.FindGameObjectsWithTag("Paper");
            return papers.Length;
        }

        public override bool CheckLevelOver()
        {
            // Player has closed 5 brackets or hit 5 wrong brackets
            if (GameManager.instance.GetPlayerPoints() >= 10 || GameManager.instance.GetPlayerPoints() <= -5)
            {
                return true;
            }
            return false;
        }

        public override void SetLevelText()
        {
            int playerPoints = GameManager.instance.GetPlayerPoints();
            int coworkerPoints = GameManager.instance.GetAntiPlayerPoints();
        }
    }
}

