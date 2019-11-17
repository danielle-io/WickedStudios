using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace WickedStudios
{
    public class Boss : MonoBehaviour
    {
        public AudioClip paperPassedToBoss;

        void Update()
        {
            PaperPickup paper = new PaperPickup();
            GameManager Gm = new GameManager();

            GameObject playerLocation = GameObject.FindGameObjectsWithTag("Player")[0];
            float playerDistance = Vector3.Distance(transform.position, playerLocation.transform.position);
            if (playerDistance <= 1.2 && paper.GetPlayerHasPaper())
            {
                Debug.Log("PAPER PASSED TO BOSS BY PLAYER ");

                Gm.SetPlayerPoints(1);

                paper.SetPlayerHasPaper(false);
            }

            GameObject coworkerLocation = GameObject.FindGameObjectsWithTag("Coworker")[0];
            float coworkerDistance = Vector3.Distance(transform.position, coworkerLocation.transform.position);

            // this part is in the coworker script already.... read note about why in coworker
            //Debug.Log("coworker distance :: " + coworkerDistance);
            if (coworkerDistance <= .9f && paper.GetCoworkerHasPaper())
            {
                //Gm.SetAntiPlayerPoints(1);
                //Debug.Log("setting has paper to false ");
                //paper.SetCoworkerHasPaper(false);
                //coworker.SetShortestDistance();
            }

        }
    }
}
