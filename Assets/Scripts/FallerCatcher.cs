using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WickedStudios
{
    public class FallerCatcher : MonoBehaviour
    {
        public float speed = 1000;
        GameManager Gm = new GameManager();


        private string currentTarget = "LeftP";
      
        void Update()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;

            Debug.Log("current target :: " + currentTarget);

        }

        private void OnCollisionEnter()
        {
            //Debug.Log("ON COLLISION");
            //Destroy(gameObject);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {


            Debug.Log("collision.gameObject.tag :: " + collision.gameObject.tag);

            if (collision.gameObject.tag != currentTarget)
            {
                Gm.SetAntiPlayerPoints(1);
                Debug.Log("LOST a point");
            }

            if (collision.gameObject.tag == currentTarget)
            {
                Gm.SetPlayerPoints(1);
                Debug.Log("GAINED a point");

                switch (collision.gameObject.tag)
                {
                    case "LeftP":
                        currentTarget = "RightP";
                        break;
                    case "RightP":
                        currentTarget = GetNextLeft();
                        break;
                    case "LeftB":
                        currentTarget = "RightB";
                        break;
                    case "RightB":
                        currentTarget = GetNextLeft();
                        break;
                    case "LeftC":
                        currentTarget = "RightC";
                        break;
                    case "RightC":
                        currentTarget = GetNextLeft();
                        break;
                }
            }
            //Destroy(gameObject);
        }
        public string GetNextLeft()
        {
            BoardManager Bm = new BoardManager();
            string[] leftArr = { "LeftC", "LeftP", "LeftB" };
            return leftArr[Bm.ChooseRandomNumInRange(0, leftArr.Length - 1)];
        }

    }

   
}