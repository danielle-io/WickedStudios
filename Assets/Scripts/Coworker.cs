using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace WickedStudios
{
    //Enemy inherits from MovingObject, our base class for objects that can move, Player also inherits from this.
    public class Coworker : MonoBehaviour
    {
        //Variable of type Animator to store a 
        // reference to the coworker's Animator component.
        //private Animator animator;	

        //private bool paperTargetFound = false;
        //public float coworkerSpeed = .00001f;
        //private GameObject[] paper;
        //private Transform targetPaper;
        //private GameObject boss;
        //private Transform targetBoss;
        //private static int points = 0;


        //GameObject[] targets;
        //GameObject shortestTarget = null;
        //float shortestDistance = Mathf.Infinity;

        //// delivery point, or your can use FindGameObjectWithTag("Point")
        //public GameObject pointed;
        //bool getitem = false;
        //GameObject[] obstacles;

        ////Start overrides the virtual Start function of the base class.
        //protected override void Start()
        //{
        //    //Get and store a reference to the attached Animator component.
        //    //animator = GetComponent<Animator> ();

        //    //Call the start function of our base class MovingObject.
        //    base.Start();

        //    obstacles = GameObject.FindGameObjectsWithTag("Obstacles");
        //}

        ////Override the AttemptMove function of MovingObject to include functionality needed for Enemy to skip turns.
        ////See comments in MovingObject for more on how base AttemptMove function works.
        //protected override void AttemptMove<T>(int xDir, int yDir)
        //{
        //    //Call the AttemptMove function from MovingObject.
        //    base.AttemptMove<T>(xDir, yDir);
        //}

        //public void OnTriggerEnter2D(Collider2D collision)
        //{
        //}

        //void Update()
        //{
        //    LevelOne lvlOne = new LevelOne();
        //    PaperPickup paperPickup = new PaperPickup();

        //    Debug.Log("in coworker paperObjectsLeft are " + lvlOne.GetPaperObjectsLeft());


        //    // If there's paper
        //    if (lvlOne.GetPaperObjectsLeft() > 0)
        //    {
        //        // If coworker does not have paper, find & get it
        //        if (!paperPickup.GetCoworkerHasPaper())
        //        {
        //            Debug.Log("Coworker does not have paper");
        //            if (!paperTargetFound || targetPaper == null)
        //            {
        //                GetPaperTarget();
        //            }

        //            if (paperTargetFound)
        //            {
        //                float step = coworkerSpeed * Time.deltaTime;
        //                transform.position = Vector3.MoveTowards(transform.position, targetPaper.position, step);
        //            }
        //        }

        //        if (paperPickup.GetCoworkerHasPaper())
        //        {
        //            Debug.Log("coworker has paper look for boss now ");
        //            paperTargetFound = false;
        //            boss = GameObject.FindGameObjectWithTag("Boss");
        //            targetBoss = boss.transform;
        //            float step = coworkerSpeed * Time.deltaTime;
        //            transform.position = Vector3.MoveTowards(transform.position, targetBoss.position, step);
        //        }
        //    }
        //}

        //public void GetPaperTarget()
        //{
        //    LevelOne lvlOne = new LevelOne();
        //    if (lvlOne.GetPaperObjectsLeft() > 0)
        //    {
        //        PaperPickup paperPickup = new PaperPickup();
        //        // If coworker does not have paper, find & move
        //        // towards it
        //        if (!paperPickup.GetCoworkerHasPaper())
        //        {
        //            paper = GameObject.FindGameObjectsWithTag("Paper");
        //            targetPaper = paper[Random.Range(0, paper.Length)].transform;
        //            Debug.Log("in getPaperTarget, target paper is " + targetPaper);
        //        }
        //        paperTargetFound = true;
        //    }
        //}

        ////OnCantMove is called if Enemy attempts to move into a space occupied by a Player, it overrides the OnCantMove function of MovingObject 
        ////and takes a generic parameter T which we use to pass in the component we expect to encounter, in this case Player
        //protected override void OnCantMove<T>(T component)
        //{
        //}

        //public void SetPoints()
        //{
        //    points += 1;
        //}

        //void avoid()//to avoid the moving  
        //{
        //    foreach (GameObject obstacle in obstacles)
        //    {
        //        float obstacleDistance = Vector3.Distance(transform.position, obstacle.transform.position);
        //        if (obstacleDistance <= 1.2)
        //        {
        //            Vector3 obstacleDirection = obstacle.transform.position - transform.position;
        //            transform.Translate(-obstacleDirection.normalized * 2 * Time.deltaTime);
        //        }
        //    }
        //}

        private GameObject[] targets;
        private List<GameObject> obstacles = new List<GameObject>();
        private GameObject boss;
        private GameObject closestTarget;
        private Transform targetBoss;
        private float shortestDistance = Mathf.Infinity;
        private int coworkerPoints = 0;
        private Animator animator;
        private bool levelOver = false;
        public float coworkerSpeed = .00001f;

        void Start()
        {
            SetObstacles();
            targets = GameObject.FindGameObjectsWithTag("Paper");
        }

        void Update()
        {
            GameManager Gm = new GameManager();
            //if (!Gm.GetLevelOver())
            //{
                // Player could move so avoid them
                SetObstacles();
                if (!levelOver)
                {
                    PaperPickup paperPickup = new PaperPickup();

                    Debug.Log("get coworker has paper :: " + paperPickup.GetCoworkerHasPaper());

                    // If coworker does not have paper, find & move towards it
                    if (!paperPickup.GetCoworkerHasPaper())
                    {

                        Debug.Log("Looking for paper!");

                        GameObject target = FindPaper();

                        if (target != null)
                        {
                            MoveTowardsPaper();
                        }
                    }

                    if (paperPickup.GetCoworkerHasPaper())
                    {
                        MoveTowardsBoss(Gm);
                    }
                }
            //}
        }

        private void MoveTowardsPaper()
        {
            Debug.Log("Moving towards paper");
            Vector3 direction = closestTarget.transform.position - transform.position;

            Avoid();

            transform.Translate(direction.normalized * 2 * Time.deltaTime);
            if (Vector3.Distance(transform.position, closestTarget.transform.position) <= 0.3f)
            {
                PaperPickup paper = new PaperPickup();
                paper.SetCoworkerHasPaper(true);
            }
        }

        private void MoveTowardsBoss(GameManager Gm)
        {
            Debug.Log("coworker has paper");
            boss = GameObject.FindGameObjectWithTag("Boss");
            targetBoss = boss.transform;

            Vector3 direction1 = targetBoss.transform.position - transform.position;

            Avoid();
            transform.Translate(direction1.normalized * 2 * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetBoss.transform.position) <= 0.9f)
            {
                Gm.SetAntiPlayerPoints(1);

                PaperPickup paper = new PaperPickup();
                Debug.Log("setting has paper to false ");

                paper.SetCoworkerHasPaper(false);
                shortestDistance = Mathf.Infinity;
            }
        }

        private GameObject FindPaper()
        {
            targets = GameObject.FindGameObjectsWithTag("Paper");

            if (targets.Length <= 0)
            {
                levelOver = true;
            }

            foreach (GameObject target in targets)
            {
                float targetDistance = Vector3.Distance(transform.position, target.transform.position);

                if (targetDistance < shortestDistance)
                {
                    shortestDistance = targetDistance;
                    closestTarget = target;
                }
            }
            return closestTarget;
        }

        void SetObstacles()
        {
            obstacles.Clear();
            foreach (GameObject item in GameObject.FindGameObjectsWithTag("Obstacle"))
            {
                obstacles.Add(item);
            }
            obstacles.Add(GameObject.FindGameObjectsWithTag("Player")[0]);
        }


        void Avoid()
        {
            foreach (GameObject obstacle in obstacles)
            {
                float obstacleDistance = Vector3.Distance(transform.position, obstacle.transform.position);
                if (obstacleDistance <= 1.2)
                {
                    Vector3 obstacleDirection = obstacle.transform.position - transform.position;
                    transform.Translate(-obstacleDirection.normalized * 2 * Time.deltaTime);
                }
            }
        } 
    }
}

