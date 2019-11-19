﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace WickedStudios
{
    public class FallerText : MonoBehaviour
    {
        string currentTarget;
        public static FallerText instance;
        private static Text targetText;

        void Awake()
        {
            instance = this;
            targetText = GetComponent<Text>();
        }

 
        public string GetTargetText()
        {
            return currentTarget;
        }

        public void SetTargetText(string target)
        {
            currentTarget = GetCurrentFallerFromName(target);
            targetText.text = currentTarget;
        }

        private string GetCurrentFallerFromName(string fallerName)
        {
            Debug.Log("passed in " + fallerName);

            switch (fallerName)
            {
                case "LeftP":
                    Debug.Log("returning ( ");
                    return "(";
                case "RightP":
                    Debug.Log("returning ) ");
                    return ")";
                case "LeftB":
                    Debug.Log("returning [ ");
                    return "[";
                case "RightB":
                    Debug.Log("returning ] ");
                    return "]";
                case "LeftC":
                    Debug.Log("returning { ");
                    return "{";
                case "RightC":
                    Debug.Log("returning } ");
                    return "}";
                default:
                    return "error";
            }
        }

        private void Start()
        {
            Target target = new Target();

            Debug.Log("setting a random target");

            currentTarget = target.GetRandomLeftTarget();

            target.SetCurrentTarget(currentTarget);
            SetTargetText(currentTarget);

        }
    }

}
