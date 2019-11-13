using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace WickedStudios
{
    public class LevelTwo : MonoBehaviour
    {

        BoardManager BM = new BoardManager();


        public void LevelTwoSetup(GameObject faller)
        {
            Debug.Log("in setup for level 2");
            Instantiate(faller, new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);

        }

        public bool CheckLevelOver()
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

