using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


namespace WickedStudios
{
    public class SceneChanger : MonoBehaviour
    {

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void GoToLevelOneIntro()
        {
            SceneManager.LoadScene("Level1Intro");
        }

        public void GoToLevelOne()
        {
            SceneManager.LoadScene("LevelOne");
        }

    }
}
