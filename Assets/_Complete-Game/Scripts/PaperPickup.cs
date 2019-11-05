using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed
{
    public class PaperPickup : MonoBehaviour
    {
        public AudioClip clip;
        public int paperValue = 1;
        public GameManager gameManager;

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("HI PAPER");

            Destroy(gameObject);
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject);

                //player.items += itemValue;
                player.addItem(1);

            }
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
