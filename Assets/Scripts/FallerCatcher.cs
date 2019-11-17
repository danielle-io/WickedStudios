using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WickedStudios
{
    public class FallerCatcher : MonoBehaviour
    {
        public float speed = 1000;
        //Fallers fallers = new Fallers();
        // Update is called once per frame
        void Update()
        {

            //transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime, 0f, Input.GetAxis("Vertical") * Time.deltaTime);
            Debug.Log(" in faller catcher update ");
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }

        private void OnCollisionEnter()
        {
            //Debug.Log("ON COLLISION");
            Destroy(gameObject);
        }

    }
}