using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace WickedStudios
{
    public class Boss : MonoBehaviour
    {
        public AudioClip paperPassedToBoss;

        // FOR DEBUGGING

        static int count = 0;
        public void OnTriggerEnter2D(Collider2D collision)
        {
            PaperPickup paper = new PaperPickup();

            Player player = collision.GetComponent<Player>();

            if (player != null)
            {
                Debug.Log("playuh" + count);
                // runs if the player currently has a paper
                if (paper.GetPlayerHasPaper())
                {
                    Debug.Log("papuhhhh ");
                    LevelOne LvlOne = new LevelOne();

                    SoundManager.instance.RandomizeSfx(paperPassedToBoss);


                    LvlOne.LowerPaperObjectsLeft();

                    // FOR DEBUGGING ONLY
                    count += 1;
                    Debug.Log("PAPER PASSED TO BOSS BY PLAYER " + count);

                    player.addItem(1);
                    paper.SetPlayerHasPaper(false);
                }
           
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
