using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace WickedStudios
{
    public class Boss : MonoBehaviour
    {
        public AudioClip paperPassedToBoss;
        Coworker coworker = new Coworker();

        public void OnTriggerEnter2D(Collider2D collision)
        {
            PaperPickup paper = new PaperPickup();

            Player player = collision.GetComponent<Player>();

            if (collision.gameObject.tag == "Player")
            {
                // runs if the player currently has a paper
                if (paper.GetPlayerHasPaper())
                {
                    LevelOne LvlOne = new LevelOne();
                    GameManager Gm = new GameManager();

                    //SoundManager.instance.PlaySingle(paperPassedToBoss);

                    Debug.Log("PAPER PASSED TO BOSS BY PLAYER ");

                    Gm.SetPlayerPoints(1);

                    paper.SetPlayerHasPaper(false);
                }
            }

            // I had to move the coworker collision code to the coworker
            // script to get it to work for some reason :(


            //if (collision.gameObject.tag == "Coworker")
            //{
            //    if (paper.GetCoworkerHasPaper())
            //    {
            //        LevelOne LvlOne = new LevelOne();

            //        //SoundManager.instance.PlaySingle(paperPassedToBoss);
                    
            //        //Debug.Log("PAPER PASSED TO BOSS BY coworker");

            //        //coworker.SetPoints(1);

            //        //paper.SetCoworkerHasPaper(false);
            //    }
            //}

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
