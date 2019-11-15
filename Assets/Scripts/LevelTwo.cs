using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace WickedStudios
{
    public class LevelTwo : Level
    {

        BoardManager bm = new BoardManager();
        Fallers fallers = new Fallers();
        public GameObject fallerCatcher;
        //public GameObject[] fallerItems;



        public override void SetupLevel(BoardManager bm)
        {
            //GameObject faller = Get<Fallers>();
            Debug.Log("in setup for level 2");
            bm.AddObjectToBoardAtPosition(fallerCatcher, new Vector3(0, 0, 0));

            //Instantiate(fallerCatcher, new Vector3(10, -2, 0), Quaternion.identity);
            //Instantiate(fallers, new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);


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

            //fallers.Update();

        }
    }
}

