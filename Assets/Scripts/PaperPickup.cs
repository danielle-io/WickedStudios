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

        public static bool playerHasPaper = false;

        //public static int check = 0;

        // temp var
        static int count = 0;

        // Also edit this so that coworkers picking up
        // papers effects everything
        public void OnTriggerEnter2D(Collider2D collision)
        {
            //playerHasPaper = GetPlayerHasPaper();

            Player player = collision.GetComponent<Player>();
            Debug.Log("playerHasPaper " + GetPlayerHasPaper());

            if (player != null)
            {

                if (!GetPlayerHasPaper())
                {

                    //check += 1;
                    Debug.Log("PAPER GRABBED BY PLAYER ");

                    Destroy(gameObject);

                    SetPlayerHasPaper(true);

                    player.addItem(1);
                }
               
            }
        }

        public bool GetPlayerHasPaper()
        {
            return playerHasPaper;
        }


        public void SetPlayerHasPaper(bool hasPaper)
        {
            playerHasPaper = hasPaper;
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
