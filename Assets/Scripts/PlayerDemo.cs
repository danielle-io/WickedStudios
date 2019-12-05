using UnityEngine;
using UnityEngine.SceneManagement;

namespace WickedStudios
{
    public class PlayerDemo : MonoBehaviour
    {
        public float speed = 80;

        void Update()
        {
            Scene activeScene = SceneManager.GetActiveScene();

            if (activeScene.name == "Level2Intro")
            {
                var move = new Vector3(Input.GetAxis("Horizontal"), 0);
                transform.position += move * speed * Time.deltaTime;
            }
            else
            {
                var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
                transform.position += move * speed * Time.deltaTime;
            }

        }
        
    }
}

