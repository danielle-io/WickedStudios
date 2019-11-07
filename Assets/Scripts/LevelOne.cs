using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    public class LevelOne : MonoBehaviour
    {
        public static int paperObjectTotal;
        public static int paperObjectsLeft;


        public void LevelOneSetup(GameObject[] papers, GameObject[] desks, GameObject[] coworkers)
        {
            BoardManager BM = new BoardManager();

            paperObjectTotal = BM.ChooseGameObjectsFromArrAtRandom(papers, 8, 12);
            paperObjectsLeft = paperObjectTotal;
            Debug.Log("Paper total:: " + paperObjectTotal);
            Debug.Log("Paper left:: " + paperObjectsLeft);

            int deskCount = BM.ChooseGameObjectsFromArrAtRandom(desks, 2, 4);

            BM.PlaceArrOfGameObjectsAtRandom(desks, deskCount);

            BM.PlaceArrOfGameObjectsAtRandom(papers, paperObjectTotal);

            // Since we want one of each coworker in this level
            // and want them in random places
            for (int i = 0; i < coworkers.Length; i++)
            {
                Debug.Log("Employee added:: " + i);
                BM.PlaceGameObjectAtRandom(coworkers[0]);
            }
        }

        public void LowerPaperObjectsLeft()
        {
            paperObjectsLeft -= 1;
            Debug.Log("paper removed from paperObjectsLeft:: " + paperObjectsLeft);
        }

        public int getPaperObjectsLeft()
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



        // Update is called once per frame
        void Update()
        {
        }
    }
}

