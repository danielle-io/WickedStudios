using UnityEngine;
using UnityEngine.UI;

namespace WickedStudios
{
    public class CoworkersPaperScoreText : MonoBehaviour
    {
        private int points = 0;
        public static CoworkersPaperScoreText instance;
        private static Text scoreText;

        void Awake()
        {
            instance = this;
            scoreText = GetComponent<Text>();
            scoreText.text = "Their Score: " + GameManager.instance.GetAntiPlayerPoints();
        }

        public void SetCoworkersScoreText()
        {
            points = GameManager.instance.GetAntiPlayerPoints();
            Debug.Log("anti player points " + points);
            scoreText.text = "Their Score: " + points.ToString();
        }

        public int GetScoreTextPoints()
        {
            return points;
        }
    }
}
