using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{ 
    public class Fallers : MonoBehaviour
    {
        public float fallSpeed = 1.0f;
        public float spinSpeed = 250.0f;

        public float delay = .1f;
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("Spawn", delay, delay);
            Debug.Log("in start of fallrrs");
            //Debug.Log(fallers.Length);
        }

        //void Update()
        //{
        //    Debug.Log("in update in fallers");
        //    transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        //    transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
        //}

        void Spawn()
        {
            //BoardManager bm = new BoardManager();
            //int randomFaller = bm.ChooseRandomNumInRange(0, 1);
            //Debug.Log(randomFaller);
            //GameObject faller = fallers[0];
            Instantiate(gameObject, new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);
        }
    }
}
