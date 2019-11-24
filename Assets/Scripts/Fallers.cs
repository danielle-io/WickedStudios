using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    // This controls the group of fallers while
    // faller (singular) class controls ONE faller
    public class Fallers : MonoBehaviour
    {
        public float fallSpeed = .000001f;
        public static float fallTime;
        private int randomNum;
        public GameObject[] fallerItems;
        
        public float delay = .1f;


        private void Start()
        {
            ResetFallTime();
        }

        public void Update()
        {
            BoardManager bm = gameObject.GetComponent<BoardManager>();

            // Get random item from fallers array
            //BoardManager bm = new BoardManager();

            randomNum = bm.ChooseRandomNumInRange(0, fallerItems.Length - 2);

            int semicolonNum = bm.ChooseRandomNumInRange(1, 100);
            Debug.Log("random num for semicolon is " + semicolonNum);
            if (semicolonNum <= 15)
            {
                randomNum = fallerItems.Length - 1;
            }



            fallTime -= 1 * Time.deltaTime;
            
            //Debug.Log("timer is " + fallTime);
            
            if (fallTime <= 0) {

                Instantiate(fallerItems[randomNum], 
                    new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);

                ResetFallTime();

                //Debug.Log("In FALLERS current Faller is :: " + gameObject.tag);
            }
        }

        private void ResetFallTime()
        {
            fallTime = 1;

        }
    }
}
