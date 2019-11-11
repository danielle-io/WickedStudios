using UnityEngine;
using System.Collections;

namespace WickedStudios
{
	//Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
	public class Coworker : MovingObject
	{
		public AudioClip attackSound1;
        //public AudioClip attackSound2;

        //Variable of type Animator to store a 
        // reference to the coworker's Animator component.
        //private Animator animator;	

        //Transform to attempt to move toward each turn.						
        //private Transform target;
        //private Transform coworker;
        private bool paperTargetFound = false;
        public float coworkerSpeed = .00001f;
        private GameObject[] paper;
        private Transform targetPaper;
        private GameObject boss;
        private Transform targetBoss;
        		
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


        void Awake()
        {
        }

        void Update()
        {
            LevelOne lvlOne = new LevelOne();
            PaperPickup paperPickup = new PaperPickup();

            Debug.Log("in coworker paperObjectsLeft are " + lvlOne.GetPaperObjectsLeft());

            // If theres paper
            if (lvlOne.GetPaperObjectsLeft() > 0)
            {
                // If coworker does not have paper, find & get it
                if (!paperPickup.GetCoworkerHasPaper())
                {
                    Debug.Log("Coworker does not have paper");
                    if (!paperTargetFound || targetPaper == null)
                    {
                        getPaperTarget();
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

        public void getPaperTarget()
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
        // MoveEnemy is called by the GameManger 
        // each turn to tell each Enemy to try to move towards the player.
        public void MoveCoworkers()
		{

   //         Debug.Log("in move coworker");

   //         //Declare variables for X and Y axis move directions, these range from -1 to 1.
   //         //These values allow us to choose between the car\\\\\dinal directions: up, down, left and right.
   //         int xDir = 0;
			//int yDir = 0;

            //target = GameObject.FindGameObjectWithTag("Paper").transform;
            //coworker = GameObject.FindGameObjectWithTag("Coworker").transform;

            //Debug.Log("target is :: " + target.position.x);
            //Debug.Log("coworker is :: " + coworker.position.x);


            //float step = 5f * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            //If the difference in positions is approximately zero (Epsilon) do the following:
   //         if (Mathf.Abs (target.position.x - coworker.position.x) < float.Epsilon)
				
			//	////If the y coordinate of the target's (player) position is greater than the y coordinate of this enemy's position set y direction 1 (to move up). If not, set it to -1 (to move down).
			//	yDir = target.position.y > coworker.position.y ? 1 : -1;
			
			////If the difference in positions is not approximately zero (Epsilon) do the following:
			//else
				////Check if target x position is greater than enemy's x position, if so set x direction to 1 (move right), if not set to -1 (move left).
				//xDir = target.position.x > coworker.position.x ? 1 : -1;

            //Call the AttemptMove function and pass 
            //in the generic parameter Player, because Enemy 
            //is moving and expecting to potentially encounter a Player
            //transform.Translate(Vector3.right * Time.deltaTime, Camera.main.transform);

            //AttemptMove<Coworker> (xDir, yDir);
		}
		
		
		//OnCantMove is called if Enemy attempts to move into a space occupied by a Player, it overrides the OnCantMove function of MovingObject 
		//and takes a generic parameter T which we use to pass in the component we expect to encounter, in this case Player
		protected override void OnCantMove <T> (T component)
		{
			//Declare hitPlayer and set it to equal the encountered component.
			//Player hitPlayer = component as Player;
			
			//Call the LoseFood function of hitPlayer passing it playerDamage, the amount of foodpoints to be subtracted.
			//hitPlayer.LoseFood (playerDamage);
			
			//Set the attack trigger of animator to trigger Enemy attack animation.
			//animator.SetTrigger ("enemyAttack");
			
			//Call the RandomizeSfx function of SoundManager passing in the two audio clips to choose randomly between.
			//SoundManager.instance.RandomizeSfx (attackSound1, attackSound2);
		}


	}
}
