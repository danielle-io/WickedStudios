using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    public class PaperPickup : MonoBehaviour
    {
        public AudioClip clip;
        public int paperValue = 1;
        public static bool playerHasPaper = false;
        public static bool coworkerHasPaper = false;
       
       public void OnTriggerEnter2D(Collider2D collision)
        {
            LevelOne lvlOne = new LevelOne();

            Player player = collision.GetComponent<Player>();
            Coworker coworker = collision.GetComponent<Coworker>();

            if (collision.gameObject.tag == "Player")
            {
                if (!GetPlayerHasPaper())
                {
                    Debug.Log("PAPER GRABBED BY PLAYER ");
                    Destroy(gameObject);
                    if (gameObject != null)
                    {
                        Destroy(gameObject);
                        //SetPlayerHasPaper(true);
                    }
                }
            }

            if (collision.gameObject.tag == "Coworker")
            {
                if (!GetCoworkerHasPaper())
                {
                    Debug.Log("PAPER GRABBED BY COWORKER ");
                    if (gameObject != null)
                    {
                        Destroy(gameObject);
                        SetCoworkerHasPaper(true);
                    }
                }
            }
        }

        public bool GetPlayerHasPaper()
        {
            return playerHasPaper;
        }

        public bool GetCoworkerHasPaper()
        {
            return coworkerHasPaper;
        }

        public void SetPlayerHasPaper(bool hasPaper)
        {
            playerHasPaper = hasPaper;
        }

        public void SetCoworkerHasPaper(bool hasPaper)
        {
            coworkerHasPaper = hasPaper;
        }
    }
}