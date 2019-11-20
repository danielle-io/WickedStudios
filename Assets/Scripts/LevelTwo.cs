using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;


namespace WickedStudios
{
    public class LevelTwo : Level
    {
        public GameObject fallerCatcher;

        public override void SetupLevel()
        {
            BoardManager bm = gameObject.GetComponent<BoardManager>();

            bm.AddObjectToBoardAtPosition(fallerCatcher, new Vector3(3, -3.7f, 0));
        }

        public override bool CheckLevelOver()
        {
            GameManager gm = gameObject.GetComponent<GameManager>();

            // Player has closed 5 brackets or hit 5 wrong brackets
            if (gm.GetPlayerPoints() >= 10 || gm.GetPlayerPoints() <= -5)
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

