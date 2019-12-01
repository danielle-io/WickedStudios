using UnityEngine;
using UnityEngine.UI;


namespace WickedStudios
{
    public class PlayersPaperScoreText : MonoBehaviour
    {
        public static PlayersPaperScoreText instance;

        private int points = 0;
        private static Text scoreText;

        void Awake()
        {
            instance = this;
            scoreText = GetComponent<Text>();
            scoreText.text = "Your Score: " + GameManager.instance.GetPlayerPoints();
        }

        public void SetPlayerScoreText()
        {
            points = GameManager.instance.GetPlayerPoints();
            scoreText.text = "Your Score: " + points.ToString();

            Debug.Log(" player points " + points);

        }

        public int GetScoreTextPoints()
        {
            return points;
        }
    }
}
