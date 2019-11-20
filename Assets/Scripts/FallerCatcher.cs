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
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            //Target target = gameObject.GetComponent<Target>();

            //scoreText = gameObject.GetComponent<ScoreText>();
            target = gameObject.GetComponent<Target>();

            currentHit = collision.gameObject.tag;

            if (target.CheckIfHitWasTarget(currentHit))
            {
                Debug.Log("GAINED a point");
                //gm.SetPlayerPoints(1);
                GameManager.instance.SetPlayerPoints(1);

            }

            else
            {
                Debug.Log("LOST a point");

                //gm.SetPlayerPoints(-1);
                GameManager.instance.SetPlayerPoints(-1);

            }
            Destroy(collision.gameObject);
            ScoreText.instance.SetScoreText();
        }
    } 
}