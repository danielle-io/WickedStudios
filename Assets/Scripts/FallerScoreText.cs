using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace WickedStudios
{
    public class FallerScoreText : MonoBehaviour
    {
        public static FallerScoreText instance;

        private int points = 0;
        private static Text scoreText;

        void Awake()
        {
            instance = this;
            scoreText = GetComponent<Text>();
            scoreText.text = "Score: 0";
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
