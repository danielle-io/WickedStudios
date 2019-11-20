using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


namespace WickedStudios
{
    public class PlayAgain : MonoBehaviour
    {

        public void GoToMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
