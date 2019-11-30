using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using System.Collections;

namespace WickedStudios
{
    public class PlayerDemo : MonoBehaviour
    {
        private Animator animator;
        public float speed = 4;
        public static Player instance;

        //void Awake()
        //{
        //    if (instance == null)
        //    {
        //        instance = this;
        //    }
        //    else if (instance != this)
        //    {
        //        Destroy(gameObject);
        //    }

        //     DontDestroyOnLoad(gameObject);
        //}
        void Start()
        {
         
            animator = GetComponent<Animator> ();
        }

        void Update()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }
        
    }
}

