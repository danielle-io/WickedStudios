using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace WickedStudios
{
    public class ScoreText : MonoBehaviour
    {
        int points;
        public static ScoreText instance;
        private static Text scoreText;

        void Awake()
        {
            instance = this;
            scoreText = GetComponent<Text>();
            scoreText.text = "Score: " + GameManager.instance.GetPlayerPoints();
        }

        public void SetScoreText()
        {
            points = GameManager.instance.GetPlayerPoints();
            scoreText.text = "Score: " + points.ToString();
        }

        public int GetScoreTextPoints()
        {
            return points;
        }
    }
}
