using UnityEngine;

namespace WickedStudios
{
    public class LevelOne : MonoBehaviour
    {
        public static int paperObjectTotal;
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
            
            for (int i = 0; i < paperObjectTotal; i++)
            {
                Vector3 paperPosition = new Vector3();
                paperPosition = bm.GetRandomPosition(paper);
                bm.AddObjectToBoardAtPosition(paper, paperPosition);
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

