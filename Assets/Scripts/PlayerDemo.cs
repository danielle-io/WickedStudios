using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using System.Collections;

namespace WickedStudios
{
    public class PlayerDemo : MonoBehaviour
    {
        public float speed = 4;

        void Start()
        {
        }

        void Update()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }
        
    }
}

