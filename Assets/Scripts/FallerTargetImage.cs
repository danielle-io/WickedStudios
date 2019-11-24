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
        public static GameObject currentTargetImage;

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

            Debug.Log("in set target image and target str is " + target);

            int arrValue = GetCurrentFallerArrIndexFromTag(target);
            Destroy(currentTargetImage);
            currentTargetImage = fallerSprites[arrValue];

            //Instantiate(currentTargetImage,
                    //new Vector3(5, 4, 0), Quaternion.identity);




            //for (int i = 0; i < fallerSprites.Length; i++)
            //{
            //    GameObject current = fallerSprites[i];
            //    Debug.Log( " at index :: " + i);
            //}

            //GameObject currentFaller = fallerSprites[arrValue];



            //Debug.Log("Have current sprite... " + currentFaller.tag);
           
            Instantiate(currentTargetImage, new Vector3(5, 4, 0), Quaternion.identity);

        }

        private void LoadFallerHashtableOfTagsAndArrayInd()
        {
            for (int i = 0; i < fallerSprites.Length; i++)
            {
                //GameObject current = fallerSprites[i];
                Debug.Log("Tag is :: " + fallerSprites[i].tag + " at index :: " + i);

                fallerArrayIndex.Add(fallerSprites[i].tag, i);
            }

                Debug.Log("Key LeftP is :: " + fallerArrayIndex["LeftP"]);
                Debug.Log("Key RightP is :: " + fallerArrayIndex["RightP"]);


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
                    return (int)fallerArrayIndex["LeftP"];
                case "RightP":
                    //Debug.Log("returning ) ");
                    return (int)fallerArrayIndex["RightP"];
                case "LeftB":
                    //Debug.Log("returning [ ");
                    return (int)fallerArrayIndex["LeftB"];
                case "RightB":
                    //Debug.Log("returning ] ");
                    return (int)fallerArrayIndex["RightB"];
                case "LeftC":
                    //Debug.Log("returning { ");
                    return (int)fallerArrayIndex["LeftC"];
                case "RightC":
                    //Debug.Log("returning } ");
                    return (int)fallerArrayIndex["RightC"];
                default:
                    Debug.Log("Invalid fallerName");
                    return (int)fallerArrayIndex["LeftP"];
            }
        }

        private void Start()
        {
            LoadFallerHashtableOfTagsAndArrayInd();
            currentTarget = Target.instance.GetRandomLeftTarget();

            Debug.Log("random target is " + currentTarget);

            Target.instance.SetCurrentTarget(currentTarget);

            int arrValue = GetCurrentFallerArrIndexFromTag(currentTarget);

            currentTargetImage = fallerSprites[arrValue];

            Instantiate(currentTargetImage,
                    new Vector3(5, 4, 0), Quaternion.identity);
        }
    }
}
