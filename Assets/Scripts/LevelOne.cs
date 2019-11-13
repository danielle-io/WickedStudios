using UnityEngine;

namespace WickedStudios
{
    // LevelOne inherits from Level, our base class for levels.
    public class LevelOne : Level
    {
        public static int paperObjectTotal;
        //public static int paperObjectsLeft;

        // Overrides the base class SetupLevel.
        public override void SetupLevel(BoardManager bm)
        {
            AddCharacters(bm);
            AddSetPositionObjects(bm);
            AddRandomPositionObjects(bm);
        }

        private void AddSetPositionObjects(BoardManager bm)
        {
            // A set array of desk positions (for now at least)
            Vector3[] deskPositions = { new Vector3(1, 5, 0),
                new Vector3(4, 5, 0), new Vector3(7, 5, 0)};

            // Hard coding desk positions (for now at least)
            for (int i = 0; i < 3; i++)
            {
                bm.AddObjectToBoardAtPosition(bm.desks[0], deskPositions[i]);
            }

            // Plant placement
            bm.AddObjectToBoardAtPosition(bm.plant, new Vector3(0, 7.6f, 0));
        }

        private void AddCharacters(BoardManager bm)
        {
            // Add single coworker (for now at least)
            Vector3 coworkerPosition = new Vector3();
            coworkerPosition = bm.GetRandomPosition(bm.coworker);
            bm.AddObjectToBoardAtPosition(bm.coworker, coworkerPosition);

            // Add player
            Vector3 playerPosition = new Vector3();
            playerPosition = bm.GetRandomPosition(bm.player);
            bm.AddObjectToBoardAtPosition(bm.player, playerPosition);

            // Add boss to set position
            bm.AddObjectToBoardAtPosition(bm.boss, new Vector3(7, 7, 0));
        }

        public void AddRandomPositionObjects(BoardManager bm)
        {
            // Paper: get random count, set total paper, set each paper
            paperObjectTotal = bm.ChooseRandomNumInRange(8, 10);
            
            for (int i = 0; i < paperObjectTotal; i++)
            {
                Vector3 paperPosition = new Vector3();
                paperPosition = bm.GetRandomPosition(bm.paper);
                bm.AddObjectToBoardAtPosition(bm.paper, paperPosition);
            }
         }
         
         public int GetPaperObjectsLeft()
        {
            GameObject[] paper = GameObject.FindGameObjectsWithTag("Paper");
            return paper.Length;
        }

        public override bool CheckLevelOver()
        {
            return (GetPaperObjectsLeft() == 0);
        }
    }
}

