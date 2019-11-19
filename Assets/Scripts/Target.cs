using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WickedStudios
{
    public class Target
    {
        private static string currentTarget;

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

                FallerText fallerText = new FallerText();
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
            BoardManager Bm = new BoardManager();
            string[] leftArr = { "LeftC", "LeftP", "LeftB" };
            string returningTarget = leftArr[Bm.ChooseRandomNumInRange(0, leftArr.Length - 1)];

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