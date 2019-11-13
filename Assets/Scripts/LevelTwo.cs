using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace WickedStudios
{
    public class LevelTwo : Level
    {

        BoardManager BM = new BoardManager();


        public override void SetupLevel(BoardManager bm)
        {
            Debug.Log("in setup for level 2");
            Instantiate(faller, new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);

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

