using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    public class PaperPickup : MonoBehaviour
    {
        public AudioClip clip;
        public int paperValue = 1;
        public GameManager gameManager;

        // temp var
        int count = 0;

        // Also edit this so that coworkers picking up
        // papers effects everything
        public void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("PAPER GRABBED BY PLAYER " + count++);

            Destroy(gameObject);

            LevelOne LvlOne = new LevelOne();
            LvlOne.setPaperObjectsLeft();

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
