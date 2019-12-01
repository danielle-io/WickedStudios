using UnityEngine;

namespace WickedStudios
{
    public class Desk : MonoBehaviour
    {
        public int assignedNum = 99999;

        void Update()
        {
            GameObject playerLocation = GameObject.FindGameObjectsWithTag("Player")[0];
            float playerDistance = Vector3.Distance(transform.position, playerLocation.transform.position);
            if (playerDistance <= .9)
            {
                Debug.Log("Collided with a desk");
                Debug.Log("assigned num is" + assignedNum );

                //GameManager.instance.SetPlayerPoints(1);
                //SoundManager.instance.RandomizeSfx (paperPassedToBoss);
                PlayersPaperScoreText.instance.SetPlayerScoreText();

            }
        }
    }
}

