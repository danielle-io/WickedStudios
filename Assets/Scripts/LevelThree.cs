﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    public class LevelThree : Level
    {

        private void Awake()
        {
            GameManager.instance.SetLevel(3);
        }

        public void LevelThreeSetup()
        {

        }

        public void BoardSetup(int rows, int columns)
        {
                
        }
            
        public override void SetupLevel(BoardManager bm)
        {
        }

        public override bool CheckLevelOver()
        {
            return false;
        }

        void Start()
        {

        }

        void Update()
        {

        }

        public override void SetLevelText()
        {

        }
    }
}

