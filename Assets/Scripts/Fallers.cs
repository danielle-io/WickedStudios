﻿using System.Collections;
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
            // Get random item from fallers array
            //BoardManager bm = new BoardManager();
            randomNum = ChooseRandomNumInRange(0, fallerItems.Length - 1);

            fallTime -= 1 * Time.deltaTime;
            
            //Debug.Log("timer is " + fallTime);
            
            if (fallTime <= 0) {
                //transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
                //transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
                //transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
                //Faller faller = new Faller();
                //faller.AddFaller(fallerItems[randomNum]);

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


        public int ChooseRandomNumInRange(int minimum, int maximum)
        {
            return Random.Range(minimum, maximum + 1);
        }

    }
}
