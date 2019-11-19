using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    public class Faller : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "FallerCatcher")
            {
                //Destroy(gameObject);
            }
        }

        //public void AddFaller(GameObject faller)
        //{
        //    Instantiate(faller,
        //        new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);
        //}

    }
}
