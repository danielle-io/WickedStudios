using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    public class LevelOne : MonoBehaviour
    {
        public static int paperObjectTotal;
        public static int paperObjectsLeft;
        public static ArrayList paperLocationList = new ArrayList();

        public void LevelOneSetup(GameObject player, GameObject[] papers, 
            GameObject[] desks, GameObject[] coworkers, 
            GameObject boss, GameObject plant)
        {
            BoardManager BM = new BoardManager();

            // Boss position
            Vector2 position = new Vector2(7, 7);
            Instantiate(boss, position, Quaternion.identity);
            BM.SetOccupiedPositions(position);

            // Hard coding desk positions for now at least
            position = new Vector2(1, 5);
            Instantiate(desks[0], position, Quaternion.identity);
            BM.SetOccupiedPositions(position);

            position = new Vector2(4, 5);
            Instantiate(desks[0], position, Quaternion.identity);
            BM.SetOccupiedPositions(position);

            position = new Vector2(7, 5);
            Instantiate(desks[0], position, Quaternion.identity);
            BM.SetOccupiedPositions(position);

            // Plant placement
            position = new Vector2(0, 7.6f);
            Instantiate(plant, position, Quaternion.identity);
            BM.SetOccupiedPositions(position);

            paperObjectTotal = BM.ChooseGameObjectsFromArrAtRandom(4, 8);
            paperObjectsLeft = paperObjectTotal;

            //BM.PlaceArrOfGameObjectsAtRandom(desks, deskCount);
            //BM.PlaceArrOfGameObjectsAtRandom(papers, paperObjectTotal);

            BM.PlaceGameObjectAtRandom(player);

            for (int i = 0; i < paperObjectTotal; i++)
            {
                BM.PlaceGameObjectAtRandom(papers[0]);
            }

            // Since we want one of each coworker in this level
            // and want them in random places
            for (int i = 0; i < coworkers.Length; i++)
            {
                Debug.Log("Coworker added:: " + i);
                BM.PlaceGameObjectAtRandom(coworkers[i]);
            }
        }

        public void LowerPaperObjectsLeft()
        {
            paperObjectsLeft -= 1;
            Debug.Log("paper removed from paperObjectsLeft:: " + paperObjectsLeft);
        }

        public int GetPaperObjectsLeft()
        {
            return paperObjectsLeft;
        }

        public bool CheckLevelOver()
        {
            return (paperObjectsLeft == 0);
        }

        // Start is called before the first frame update
        void Start()
        {

        }
    }
}

