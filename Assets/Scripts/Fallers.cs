using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    public class Fallers : MonoBehaviour
    {
        public float fallSpeed = .0001f;
        public static float fallTime = 1;
        private int randomNum;
        public GameObject[] fallerItems;
       

        public float delay = .1f;
        void Start()

        {
            //InvokeRepeating("Spawn", delay, delay);
            //Debug.Log("in start of fallers");
            //Debug.Log(fallers.Length);
             
        }

        public void Update()
        {
            // Get random item from fallers array

            Debug.Log(fallerItems.Length);
            BoardManager bm = new BoardManager();

            randomNum = bm.ChooseRandomNumInRange(0, fallerItems.Length - 1);

            //Debug.Log("in update in fallers random num is " + randomNum);


            //transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
            //transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
            //BoardManager bm = new BoardManager();
            //int randomFaller = bm.ChooseRandomNumInRange(0, 1);
            //Debug.Log(randomFaller);
            //GameObject faller = fallers[0];

            fallTime -= 1 * Time.deltaTime;
            
            //Debug.Log("timer is " + fallTime);
            
            if (fallTime <= 0) {
                //Debug.Log("INSTANTIATING " + fallTime);
                //transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

                //transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);

                //BoardManager bm = new BoardManager();

                //transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);


                Instantiate(fallerItems[randomNum], new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);
                fallTime = 1;
            }
}

        void Spawn()
        {
   
        }
    }   
}
