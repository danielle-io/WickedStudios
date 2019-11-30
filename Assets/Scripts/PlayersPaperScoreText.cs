using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace WickedStudios
{
    public class PlayersPaperScoreText : MonoBehaviour
    {
        int points;
        public static PlayersPaperScoreText instance;
        private static Text scoreText;

        void Awake()
        {
            instance = this;
            scoreText = GetComponent<Text>();
            //scoreText.text = "Your Score: " + GameManager.instance.GetPlayerPoints();
        }

        public void SetPlayerScoreText()
        {
            points = GameManager.instance.GetPlayerPoints();
            //scoreText.text = "Your Score: " + points.ToString();

            //Debug.Log(" player points " + points);

        }

        public int GetScoreTextPoints()
        {
            return points;
        }
    }
}
