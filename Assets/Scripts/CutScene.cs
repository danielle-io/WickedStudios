using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace WickedStudios
{
    public class CutScene : MonoBehaviour
    {
        public Image graduation;
        public Image office;

        public void setActive()
        {
            graduation.gameObject.SetActive(false);
            office.gameObject.SetActive(true);
        }

        public void goToNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}

