using UnityEngine;
using UnityEngine.SceneManagement;


namespace WickedStudios
{
    public class SceneChanger : MonoBehaviour
    {

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void GoToGameIntro()
        {
            SceneManager.LoadScene("GameIntro");
        }

        public void GoToLevelOneIntro()
        {
            SceneManager.LoadScene("Level1Intro");
        }

        public void GoToLevelOne()
        {
            SceneManager.LoadScene("Level1");
        }

        public void GoToLevelTwoIntro()
        {
            SceneManager.LoadScene("Level2Intro");
        }

        public void GoToLevelTwo()
        {
            SceneManager.LoadScene("Level2");
        }
        public void GoToStartOver()
        {
            int level = GameManager.instance.GetLevel();
            switch (level)
            {
                case 1:
                    GoToLevelOne();
                    return;
                case 2:
                    GoToLevelTwo();
                    return;
                default:
                    return;
            }
        }

    }
}
