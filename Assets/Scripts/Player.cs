using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;
using System.Collections;

namespace WickedStudios
{
    public class Player : MonoBehaviour
    {
        private Animator animator;
        public float speed = 4;

        void Start()
        {
            animator = GetComponent<Animator> ();
        }

        void Update()
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }

        //OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
		private void OnTriggerEnter2D (Collider2D other)
		{
			//Check if the tag of the trigger collided with is Exit.
			if(other.tag == "Paper")
			{
				animator.SetTrigger("janeWithPaper");
			}

            if(other.tag == "Boss")
            {
                animator.SetTrigger("janeForward");
            }
        }
        
    }
}

