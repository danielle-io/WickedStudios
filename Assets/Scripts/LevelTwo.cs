using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;


namespace WickedStudios
{
    public class LevelTwo : Level
    {
        BoardManager bm;
        GameManager Gm;
        FallerCatcher Fc = new FallerCatcher();
        //Text textText;

        //TextMesh textMesh;

        private string currentTarget;

        public GameObject fallerCatcher;

        //public GameObject targetText;

        public override void SetupLevel(BoardManager bm)
        {
            bm.AddObjectToBoardAtPosition(fallerCatcher, new Vector3(3, -3.7f, 0));

            //textMesh = targetText.GetComponent<TextMesh>();


            //textText = targetText.GetComponent<Text>();

            //Instantiate(targetText, new Vector3(8, 8, 0), Quaternion.identity);

        }

        public override bool CheckLevelOver()
        {
            return false;
        }


        // Update is called once per frame
        void Update()
        {
            //Debug.Log("text is " + testMesh.text);

        }

        //void DisplayCurrentFallerText()
        //{
        //    //Debug.Log("target.GetCurrentTarget() " + target.GetCurrentTarget());
        //    //currentTarget = target.GetCurrentTarget();

        //    //currentTarget = GetCurrentFallerFromName(target.GetCurrentTarget());


        //    //Debug.Log("target.GetCurrentTarget() " + currentTarget);

        //    //textText.text = currentTarget;


        //    //currentTarget = GetCurrentFallerFromName(currentTarget);

        //    //textMesh.text = currentTarget;
        //}


        //}

      

        public override void SetLevelText()
        {

        }
    }
}

