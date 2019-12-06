using UnityEngine;
using System.Collections;

namespace WickedStudios
{
    public class FallerTargetImage : MonoBehaviour
    {
        public static FallerTargetImage instance;

        private string currentTarget = "";

        public GameObject[] fallerSprites;
        public GameObject targetSquare;
        private Hashtable fallerArrayIndex  = new Hashtable();
        private Vector3 targetPosition = new Vector3(5.28f, 3.84f, 0);
        private Vector3 targetSquarePosition = new Vector3(5.27f, 4.01f, 0);


        void Awake()
        {
            instance = this;

        }

        public string GetTargetImage()
        {
            return currentTarget;
        }

        public void SetTargetImage(string target)
        {
            GameObject[] currentTargets = GameObject.FindGameObjectsWithTag("CurrentTarget");

            foreach (GameObject targetText in currentTargets)
            {
                Destroy(targetText);
            }

            int arrValue = GetCurrentFallerArrIndexFromTag(target);

            Instantiate(fallerSprites[arrValue], targetPosition, Quaternion.identity);
        }

        private void LoadFallerHashtableOfTagsAndArrayInd()
        {
            for (int i = 0; i < fallerSprites.Length; i++)
            {
                fallerArrayIndex.Add(fallerSprites[i].name, i);
            }
        }

        private int GetCurrentFallerArrIndexFromTag(string fallerName)
        {
            switch (fallerName)
            {
                case "LeftP":
                    return (int)fallerArrayIndex["LeftPImage"];
                case "RightP":
                    return (int)fallerArrayIndex["RightPImage"];
                case "LeftB":
                    return (int)fallerArrayIndex["LeftBImage"];
                case "RightB":
                    return (int)fallerArrayIndex["RightBImage"];
                case "LeftC":
                    return (int)fallerArrayIndex["LeftCImage"];
                case "RightC":
                    return (int)fallerArrayIndex["RightCImage"];
                default:
                    Debug.Log("Invalid fallerName");
                    return (int)fallerArrayIndex["LeftPImage"];
            }
        }

        private void Start()
        {
            LoadFallerHashtableOfTagsAndArrayInd();

            currentTarget = Target.instance.GetRandomLeftTarget();

            Debug.Log("random target is " + currentTarget);

            Target.instance.SetCurrentTarget(currentTarget);

            int arrValue = GetCurrentFallerArrIndexFromTag(currentTarget);
            Instantiate(targetSquare, targetSquarePosition, Quaternion.identity);

            Instantiate(fallerSprites[arrValue],
                    targetPosition, Quaternion.identity);
        }
    }
}
