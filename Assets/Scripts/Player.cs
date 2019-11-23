using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using System.Collections;

namespace WickedStudios
{
    public class Player : MonoBehaviour
    {
        public float speed = 6;

        void Update()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }

    }
}

