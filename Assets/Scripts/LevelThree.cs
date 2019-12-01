using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace WickedStudios
{
    public class LevelThree : Level
    {
        public int columns = 11;
        public int rows = 11;

        public GameObject player;
        public GameObject plant;
        public GameObject[] desks;
        public GameObject floorTiles;

        private ArrayList deskPositionNums = new ArrayList{ 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        private Dictionary<Vector3, int> deskNums = new Dictionary<Vector3, int>();

        public static LevelOne instance = null;

        private void Update()
        {
            CheckLevelOver();
        }

        public override void SetupLevel(BoardManager bm)
        {
            bm.BoardSetup(rows, columns, floorTiles);
            bm.InitialiseList(rows, columns);
            AddCharacters(bm);
            AddSetPositionObjects(bm);
        }

        private void AddSetPositionObjects(BoardManager bm)
        {

            Vector3[] deskPositions = { 
                new Vector3(0, 7, 0),
                new Vector3(3, 7, 0), 
                new Vector3(6, 7, 0), 
                 
                new Vector3(1, 4, 0),
                new Vector3(4, 4, 0),
                new Vector3(7, 4, 0),

                new Vector3(0, 1, 0),
                new Vector3(3, 1, 0),
                new Vector3(6, 1, 0),
            };

            SetDeskNumbers(deskPositions, bm);

            for (int i = 0; i < 9; i++)
            {
                if (i <= 2 || i >= 6)
                {
                    bm.AddObjectToBoardAtPosition(desks[0], deskPositions[i]);
                }
                else
                {
                    bm.AddObjectToBoardAtPosition(desks[1], deskPositions[i]);
                }
                gameObject.GetComponent<Desk>().assignedNum = deskNums[deskPositions[i]];
            }

            // Plant placement
            bm.AddObjectToBoardAtPosition(plant, new Vector3(10, 7, 0));

        }

        private void AddCharacters(BoardManager bm)
        {
            Vector3 playerPosition = new Vector3(-1, 0, 0);
            bm.AddObjectToBoardAtPosition(player, playerPosition);
        }

        public override int CheckLevelOver()
        {
            //if (GameManager.instance.GetPlayerPoints() + GameManager.instance.GetAntiPlayerPoints() >= paperObjectTotal)
            //{
            //    if (GameManager.instance.GetPlayerPoints() < GameManager.instance.GetAntiPlayerPoints())
            //    {
            //        return -1;
            //    }
            //    if (GameManager.instance.GetPlayerPoints() > GameManager.instance.GetAntiPlayerPoints())
            //    {
            //        return 1;
            //    }
            //}
            return 0;
        }

        public override void SetLevelText()
        {
            int playerPoints = GameManager.instance.GetPlayerPoints();
            //int coworkerPoints = GameManager.instance.GetAntiPlayerPoints();
        }

        public override string GetNextScene()
        {
            return "WinGame";
        }

        private void SetDeskNumbers(Vector3[] deskPositions, BoardManager bm)
        {
            ArrayList randomList = new ArrayList();

            Random random = new Random();
            int n = deskPositionNums.Count;

            Debug.Log("desk positions length :: " + deskPositions.Length);
            Debug.Log("desk position Nums length :: " + deskPositionNums.Count);


            for (int i = 0; i < deskPositions.Length; i++)
            {

                int randomNum = Random.Range(0, deskPositionNums.Count);
                //int randomNum = bm.ChooseRandomNumInRange(0, deskPositionNums.Count);

                Debug.Log("INDEX random xnum is :: " + randomNum);

                int num = (int)deskPositionNums[randomNum];

                Debug.Log("num is :: " + num);


                deskNums[deskPositions[i]] = num;

                deskPositionNums.Remove(num);
            }
        }

        //private static void ShuffleMe<T>(this IList<T> list)
        //{
        //    Random random = new Random();
        //    int n = list.Count;

        //    for (int i = list.Count - 1; i > 1; i--)
        //    {
        //        int rnd = random.Next(i + 1);

        //        T value = list[rnd];
        //        list[rnd] = list[i];
        //        list[i] = value;
        //    }
        //}

    }
}