using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    public class LevelThree : Level
    {

        private void Awake()
        {
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

        public override int CheckLevelOver()
        {
            return 0;
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

        public override string GetNextScene()
        {
            return "WonGame";
        }
    }
}

