using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WickedStudios
{
    public class FallerCatcher : MonoBehaviour
    {
        public float speed = 1000;
        private string currentHit;

        void Update()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            currentHit = collision.gameObject.tag;
            Target target = new Target();
            GameManager Gm = new GameManager();
            if (target.CheckIfHitWasTarget(currentHit))
            {
                Debug.Log("GAINED a point");

                Gm.SetPlayerPoints(1);
            }

            else
            {
                Debug.Log("LOST a point");

                Gm.SetAntiPlayerPoints(1);
            }
            Destroy(collision.gameObject);
        }
    } 
}