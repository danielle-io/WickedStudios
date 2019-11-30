using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    public class PaperPickup : MonoBehaviour
    {   
        public static bool playerHasPaper = false;
        public static bool coworkerHasPaper = false;
        public AudioClip handlePaper1;						
		public AudioClip handlePaper2;
        public AudioClip handlePaper3;

        public static PaperPickup instance;

        void Awake()
        {
            instance = this;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Player player = collision.GetComponent<Player>();
            Coworker coworker = collision.GetComponent<Coworker>();

            if (collision.gameObject.tag == "Player")
            {
                if (!GetPlayerHasPaper())
                {
                    Debug.Log("PAPER GRABBED BY PLAYER ");
                    //SoundManager.instance.RandomizeSfx (handlePaper1, handlePaper2, handlePaper3);
                    Destroy(gameObject);
                    if (gameObject != null)
                    {
                        Destroy(gameObject);
                        SetPlayerHasPaper(true);
                    }
                }
            }

            if (collision.gameObject.tag == "Coworker")
            {
                if (!GetCoworkerHasPaper())
                {
                    Debug.Log("PAPER GRABBED BY COWORKER ");
                    //SoundManager.instance.RandomizeSfx (handlePaper1, handlePaper2, handlePaper3);
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