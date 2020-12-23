using UnityEngine;

namespace WickedStudios
{
    public class Fallers : MonoBehaviour
    {
        private int randomNum;

        public GameObject[] fallerItems;
        public float fallSpeed = .001f;
        public static float fallTime;
        public float delay = .1f;
        private int timeUntilTargetFalls = 0;
        private string fallerTarget = Target.instance.GetCurrentTarget();
        // Make a dictionary of the fallers and their index numbers here

        void Start()
        {
            ResetFallTime();
        }

        public void Update()
        {
            BoardManager bm = gameObject.GetComponent<BoardManager>();
            randomNum = bm.ChooseRandomNumInRange(0, fallerItems.Length - 2);
            

            if (GameManager.instance.GetPlayerPoints() < 0)
            {
                int semicolonNum = bm.ChooseRandomNumInRange(1, 100);

                if (semicolonNum <= 10)
                {
                    randomNum = fallerItems.Length - 1;
                }
            }

            fallTime -= 1f * Time.deltaTime;

            if (fallTime <= 0) {

                // Target hasn't been seen in 10 drops, instantiating it now


                if (timeUntilTargetFalls >= 10)
                {
                    // get the index number of the target
                    randomNum = GetArrayIndexOfTarget(currentTarget);
                    timeUntilTargetFalls = 0;
                }
                else
                {
                    timeUntilTargetFalls += 1;
                }

                Instantiate(fallerItems[randomNum], 
                    new Vector3(Random.Range(-5.5f, 5.5f), 10, 0), Quaternion.identity);

                ResetFallTime();
            }
        }

        private void ResetFallTime()
        {
            fallTime = 1;
        }

        private int GetArrayIndexOfTarget(string currentTarget)
        {

            // here grab the dictionary index the target is linked to and 
            // send that back to the update function
            return 0;
        }
    }
}
