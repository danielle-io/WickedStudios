using UnityEngine;
using System.Collections.Generic;

namespace WickedStudios
{
    public class Coworker : MonoBehaviour
    {
        private GameObject[] targets;
        private List<GameObject> obstacles = new List<GameObject>();
        private GameObject boss;
        private GameObject closestTarget;
        private float shortestDistance = Mathf.Infinity;
        private Animator animator;
        private bool levelOver = false;
        public float coworkerSpeed = .00001f;

        public static Coworker instance;

        void Awake()
        {
            instance = this;
        }

        void Start()
        {
            SetObstacles();
            targets = GameObject.FindGameObjectsWithTag("Paper");
        }

        void Update()
        {
            // Player could move so avoid them
            Debug.Log("Coworker Update");
            SetObstacles();

            if (!levelOver)
            {
                // If coworker does not have paper, find & move towards it
                if (!PaperPickup.instance.GetCoworkerHasPaper())
                {
                    //Debug.Log("Looking for paper!");
                    GameObject target = FindPaper();

                    if (target != null)
                    {
                        MoveTowardsPaper();
                    }
                }

                if (PaperPickup.instance.GetCoworkerHasPaper())
                {
                    MoveTowardsBoss();
                }
            }
        }

        private void MoveTowardsObject(GameObject target)
        {
            Vector3 direction = target.transform.position - transform.position;
            Avoid();
            transform.Translate(direction.normalized * 1 * Time.deltaTime);
        }

        private void MoveTowardsPaper()
        {
            //Debug.Log("Moving towards paper");
            MoveTowardsObject(closestTarget);

            if (Vector3.Distance(transform.position, closestTarget.transform.position) <= 0.3f)
            {
                PaperPickup.instance.SetCoworkerHasPaper(true);
            }
        }

        private void MoveTowardsBoss()
        {
            //Debug.Log("coworker has paper");
            boss = GameObject.FindGameObjectWithTag("Boss");

            MoveTowardsObject(boss);

            // I want to comment this out and comment it in in the boss script
            // (the player's detection is there, but for some reason when
            // this is in the boss script the coworker stops after delivering
            // the paper and im not sure why
            if (PaperPickup.instance.GetCoworkerHasPaper())
            {
                //if (Vector3.Distance(transform.position, boss.transform.position) <= 1.2f)
                //{

                //    GameManager.instance.SetAntiPlayerPoints(1);

                //    CoworkersPaperScoreText.instance.SetCoworkersScoreText();

                //    Debug.Log("setting has paper to false ");

                //    PaperPickup.instance.SetCoworkerHasPaper(false);
                //    shortestDistance = Mathf.Infinity;
                //}
            }
        }

        public void SetShortestDistance()
        {
            shortestDistance = Mathf.Infinity;
        }

        private GameObject FindPaper()
        {
            Debug.Log("finding paper");

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
            Debug.Log("in avoid");
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

