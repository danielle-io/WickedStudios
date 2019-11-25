using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WickedStudios
{
    public class FallerCatcher : MonoBehaviour
    {
        public float speed = 1000;
        private string currentHit;
        private Target target;

        void Update()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), 0);
            transform.position += move * speed * Time.deltaTime;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            target = gameObject.GetComponent<Target>();

            currentHit = collision.gameObject.tag;

            if (target.CheckIfHitWasTarget(currentHit))
            {
                Debug.Log("GAINED a point");
                GameManager.instance.SetPlayerPoints(1);
            }

            else
            {
                Debug.Log("LOST a point");
                GameManager.instance.SetPlayerPoints(-1);
            }
            //string tag = gameObject.tag;
            //if (tag != "Semicolon")
            //{

            //}
            Destroy(collision.gameObject);
            FallerScoreText.instance.SetScoreText();
        }
    } 
}