using UnityEngine;

namespace WickedStudios
{
    public class Target: MonoBehaviour
    {
        private static string currentTarget;
        public static Target instance;

        void Awake()
        {
            instance = this;
        }

        public bool CheckIfHitWasTarget(string currentHit)
        {

            Debug.Log("current target is :: " + currentTarget );
            Debug.Log("current hit is :: " + currentHit);

            if (currentHit != currentTarget)
            {
                return false;
            }
            else
            {
                Debug.Log("current hit in target is equal -> " + currentHit);
                currentTarget = GetNextTarget(currentHit);

                FallerTargetText fallerText = new FallerTargetText();
                fallerText.SetTargetText(currentTarget);

                Debug.Log("current target is :: " + currentTarget);
                return true;
            }
        }

        private string GetNextTarget(string currentHit)
        {
            switch (currentHit)
            {
                case "LeftP":
                    return "RightP";
                case "RightP":
                    return GetRandomLeftTarget();
                case "LeftB":
                    return "RightB";
                case "RightB":
                    return GetRandomLeftTarget();
                case "LeftC":
                    return "RightC";
                case "RightC":
                    return GetRandomLeftTarget();
                default:
                    return "null";
            }
        }

        public string GetRandomLeftTarget()
        {

            string[] leftArr = { "LeftC", "LeftP", "LeftB" };
            string returningTarget = leftArr[BoardManager.inst.ChooseRandomNumInRange(0, leftArr.Length - 1)];

            Debug.Log(returningTarget);
            return returningTarget;
        }

        public void SetCurrentTarget(string target)
        {
            Debug.Log("set to :: " + target);
            currentTarget = target;
        }

        public string GetCurrentTarget()
        {
            //Debug.Log("returning " + currentTarget);
            return currentTarget;
        }
    }
}