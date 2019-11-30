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
            GameObject playerLocation = GameObject.FindGameObjectsWithTag("Player")[0];
            float playerDistance = Vector3.Distance(transform.position, playerLocation.transform.position);
            if (playerDistance <= 1.2 && PaperPickup.instance.GetPlayerHasPaper())
            {
                Debug.Log("PAPER PASSED TO BOSS BY PLAYER ");

                GameManager.instance.SetPlayerPoints(1);
                //SoundManager.instance.RandomizeSfx (paperPassedToBoss);
                PlayersPaperScoreText.instance.SetPlayerScoreText();

                PaperPickup.instance.SetPlayerHasPaper(false);
            }

            GameObject coworkerLocation = GameObject.FindGameObjectsWithTag("Coworker")[0];
            float coworkerDistance = Vector3.Distance(transform.position, coworkerLocation.transform.position);

            // this part is in the coworker script already.... read note about why in coworker
            //Debug.Log("coworker distance :: " + coworkerDistance);
            if (coworkerDistance <= 1.2f && PaperPickup.instance.GetCoworkerHasPaper())
            {
                GameManager.instance.SetAntiPlayerPoints(1);
                CoworkersPaperScoreText.instance.SetCoworkersScoreText();

                Debug.Log("setting has paper to false ");
                PaperPickup.instance.SetCoworkerHasPaper(false);
                Coworker.instance.SetShortestDistance();
            }

        }
    }
}
