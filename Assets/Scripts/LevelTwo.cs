using UnityEngine;

namespace WickedStudios
{
    public class LevelTwo : Level
    {
        public GameObject fallerCatcher;

        private void Awake()
        {
            GameManager.instance.SetLevel(2);
        }

        public override void SetupLevel(BoardManager bm)
        {

            BoardManager.inst.AddObjectToBoardAtPosition(fallerCatcher, new Vector3(3, -3.7f, 0));
        }

        public override bool CheckLevelOver()
        {
            // Player has closed 5 brackets or hit 5 wrong brackets
            if (GameManager.instance.GetPlayerPoints() >= 10 || GameManager.instance.GetPlayerPoints() <= -5)
            {
                return true;
            }
            return false;
        }

        private void Update()
        {
            if (ScoreText.instance.GetScoreTextPoints() != GameManager.instance.GetPlayerPoints())
            {
                Debug.Log("score text and points are different");
                ScoreText.instance.SetScoreText();
            }
        }
    }
}

