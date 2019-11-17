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
     

        public void Update()
        {
            // Get random item from fallers array
            BoardManager bm = new BoardManager();
            randomNum = bm.ChooseRandomNumInRange(0, fallerItems.Length - 1);
            fallTime -= 1 * Time.deltaTime;
            
            //Debug.Log("timer is " + fallTime);
            
            if (fallTime <= 0) {
                //transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
                //transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
                //transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
                Instantiate(fallerItems[randomNum], 
                    new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);
                    fallTime = 1;
            }
        }

    }   
}
