using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace WickedStudios
{
    public class FallerTargetImage : MonoBehaviour
    {
        public static FallerTargetImage instance;

        private string currentTarget = "";

        public GameObject[] fallerSprites;
        private static Hashtable fallerArrayIndex  = new Hashtable();

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
            //currentTargetImage = 
            GameObject[] currentTargets = GameObject.FindGameObjectsWithTag("CurrentTarget");
            Debug.Log("found this many targets " + currentTargets.Length);

            foreach (GameObject targetText in currentTargets)
            {
                Destroy(targetText);
            }

            

            Debug.Log("in set target image and target str is " + target);

            int arrValue = GetCurrentFallerArrIndexFromTag(target);
            //currentTargetImage = fallerSprites[arrValue];

            //for (int i = 0; i < fallerSprites.Length; i++)
            //{
            //    GameObject current = fallerSprites[i];
            //    Debug.Log( " at index :: " + i);
            //}

            //GameObject currentFaller = fallerSprites[arrValue];

            //Debug.Log("Have current sprite... " + currentFaller.tag);

            Instantiate(fallerSprites[arrValue], new Vector3(5, 4, 0), Quaternion.identity);

        }

        private void LoadFallerHashtableOfTagsAndArrayInd()
        {
            for (int i = 0; i < fallerSprites.Length; i++)
            {
                //GameObject current = fallerSprites[i];
                Debug.Log("Name is :: " + fallerSprites[i].name + " at index :: " + i);

                fallerArrayIndex.Add(fallerSprites[i].name, i);
            }

                //Debug.Log("Key LeftP is :: " + fallerArrayIndex["LeftP"]);
                Debug.Log("Key RightP is :: " + fallerArrayIndex["RightPImage"]);


            //for (int i = 0; i < fallerArrayIndex.Count; i++)
            //{
            //    Debug.Log("Value is :: " + fallerArrayIndex[i]);
            //}
        }

        private int GetCurrentFallerArrIndexFromTag(string fallerName)
        {
            switch (fallerName)
            {
                case "LeftP":
                    //Debug.Log("returning ( ");
                    return (int)fallerArrayIndex["LeftPImage"];
                case "RightP":
                    //Debug.Log("returning ) ");
                    return (int)fallerArrayIndex["RightPImage"];
                case "LeftB":
                    //Debug.Log("returning [ ");
                    return (int)fallerArrayIndex["LeftBImage"];
                case "RightB":
                    //Debug.Log("returning ] ");
                    return (int)fallerArrayIndex["RightBImage"];
                case "LeftC":
                    //Debug.Log("returning { ");
                    return (int)fallerArrayIndex["LeftCImage"];
                case "RightC":
                    //Debug.Log("returning } ");
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

            //currentTargetImage = fallerSprites[arrValue];

            Instantiate(fallerSprites[arrValue],
                    new Vector3(5, 4, 0), Quaternion.identity);
        }
    }
}
