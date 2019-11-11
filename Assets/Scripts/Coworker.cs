using UnityEngine;
using System.Collections;

namespace WickedStudios
{
	//Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
	public class Coworker : MovingObject
	{
        //Variable of type Animator to store a 
        // reference to the coworker's Animator component.
        //private Animator animator;	

        private bool paperTargetFound = false;
        public float coworkerSpeed = .00001f;
        private GameObject[] paper;
        private Transform targetPaper;
        private GameObject boss;
        private Transform targetBoss;
        private static int points = 0;
        		
		//Start overrides the virtual Start function of the base class.
		protected override void Start ()
		{
			//Get and store a reference to the attached Animator component.
			//animator = GetComponent<Animator> ();
			
            //Call the start function of our base class MovingObject.
            base.Start ();
		}
		
		//Override the AttemptMove function of MovingObject to include functionality needed for Enemy to skip turns.
		//See comments in MovingObject for more on how base AttemptMove function works.
		protected override void AttemptMove <T> (int xDir, int yDir)
		{			
			//Call the AttemptMove function from MovingObject.
			base.AttemptMove <T> (xDir, yDir);
		}

        public void OnTriggerEnter2D(Collider2D collision)
        {
        }

        void Update()
        {
            LevelOne lvlOne = new LevelOne();
            PaperPickup paperPickup = new PaperPickup();

            Debug.Log("in coworker paperObjectsLeft are " + lvlOne.GetPaperObjectsLeft());

            // If there's paper
            if (lvlOne.GetPaperObjectsLeft() > 0)
            {
                // If coworker does not have paper, find & get it
                if (!paperPickup.GetCoworkerHasPaper())
                {
                    Debug.Log("Coworker does not have paper");
                    if (!paperTargetFound || targetPaper == null)
                    {
                        GetPaperTarget();
                    }

                    if (paperTargetFound)
                    {
                        float step = coworkerSpeed * Time.deltaTime;
                        transform.position = Vector3.MoveTowards(transform.position, targetPaper.position, step);
                    }
                }

                if (paperPickup.GetCoworkerHasPaper())
                {
                    Debug.Log("coworker has paper look for boss now ");
                    paperTargetFound = false;
                    boss = GameObject.FindGameObjectWithTag("Boss");
                    targetBoss = boss.transform;
                    float step = coworkerSpeed * Time.deltaTime;
                    transform.position = Vector3.MoveTowards(transform.position, targetBoss.position, step);
                }
            }
        }

        public void GetPaperTarget()
        {
            LevelOne lvlOne = new LevelOne();
            if (lvlOne.GetPaperObjectsLeft() > 0)
            {
                PaperPickup paperPickup = new PaperPickup();
                // If coworker does not have paper, find & move
                // towards it
                if (!paperPickup.GetCoworkerHasPaper())
                {
                    paper = GameObject.FindGameObjectsWithTag("Paper");
                    targetPaper = paper[Random.Range(0, paper.Length)].transform;
                    Debug.Log("in getPaperTarget, target paper is " + targetPaper);
                }
                paperTargetFound = true;
            }
        }

		//OnCantMove is called if Enemy attempts to move into a space occupied by a Player, it overrides the OnCantMove function of MovingObject 
		//and takes a generic parameter T which we use to pass in the component we expect to encounter, in this case Player
		protected override void OnCantMove <T> (T component)
		{
		}

        public void SetPoints()
        {
            points += 1;
        }
    }
}
