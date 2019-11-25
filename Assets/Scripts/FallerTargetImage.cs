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
            GameObject[] currentTargets = GameObject.FindGameObjectsWithTag("CurrentTarget");

            foreach (GameObject targetText in currentTargets)
            {
                Destroy(targetText);
            }

            int arrValue = GetCurrentFallerArrIndexFromTag(target);

            Instantiate(fallerSprites[arrValue], new Vector3(5, 4, 0), Quaternion.identity);

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
            
            Instantiate(fallerSprites[arrValue],
                    new Vector3(5, 4, 0), Quaternion.identity);
        }
    }
}
