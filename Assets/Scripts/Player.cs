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

            //Check if the tag of the trigger collided with is Exit.
            if (PaperPickup.instance.GetPlayerHasPaper())
            {
                animator.SetTrigger("janeWithPaper");
            }

            else
            {
                animator.SetTrigger("janeForward");
            }
        }
        
    }
}

