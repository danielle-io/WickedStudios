using UnityEngine;

namespace WickedStudios
{
    public class LevelTwo : Level
    {
        public GameObject fallerCatcher;
        public static LevelTwo instance = null;

        public override void SetupLevel(BoardManager bm)
        {
            bm.AddObjectToBoardAtPosition(fallerCatcher, new Vector3(0, -3.7f, 0));
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
            //if (FallerScoreText.instance.GetScoreTextPoints() != GameManager.instance.GetPlayerPoints())
            //{
            //    Debug.Log("score text and points are different");
            //    FallerScoreText.instance.SetScoreText();
            //}
        }
    }
}

