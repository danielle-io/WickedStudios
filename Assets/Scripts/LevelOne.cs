﻿using UnityEngine;

namespace WickedStudios
{
    public class LevelOne : Level
    {
        public int columns = 9;
        public int rows = 9;
        public static int paperObjectTotal;

        public GameObject boss;
        public GameObject player;
        public GameObject plant;
        public GameObject coworker;
        public GameObject paper;
        public GameObject[] desks;
        public GameObject outerWallTiles;
        public GameObject floorTiles;

        public static LevelOne instance = null;

        private void Update()
        {
            CheckLevelOver();
        }

        // Overrides the base class SetupLevel.
        public override void SetupLevel(BoardManager bm)
        {
            bm.BoardSetup(rows, columns, outerWallTiles, floorTiles);
            bm. InitialiseList(rows, columns);
            AddCharacters(bm);
            AddSetPositionObjects(bm);
            AddRandomPositionObjects(bm);
        }

        private void AddSetPositionObjects(BoardManager bm)
        {
            // A set array of desk positions (for now at least)
            Vector3[] deskPositions = { new Vector3(1, 5, 0),
                new Vector3(4, 5, 0), new Vector3(7, 5, 0)};

            // Hard coding desk positions (for now at least)
            for (int i = 0; i < 3; i++)
            {
                bm.AddObjectToBoardAtPosition(desks[0], deskPositions[i]);
            }

            // Plant placement
            bm.AddObjectToBoardAtPosition(plant, new Vector3(0, 7.6f, 0));
        }

        private void AddCharacters(BoardManager bm)
        {
            // Add single coworker (for now at least)
            Vector3 coworkerPosition = bm.GetRandomPosition(coworker);
            bm.AddObjectToBoardAtPosition(coworker, coworkerPosition);

            // Add player
            Vector3 playerPosition = bm.GetRandomPosition(player);
            bm.AddObjectToBoardAtPosition(player, playerPosition);

            // Add boss to set position
            bm.AddObjectToBoardAtPosition(boss, new Vector3(7, 7, 0));
        }

        public void AddRandomPositionObjects(BoardManager bm)
        {

            // Paper: get random count, set total paper, set each paper
            paperObjectTotal = bm.ChooseRandomNumInRange(8, 10);
            
            for (int i = 0; i < paperObjectTotal; i++)
            {
                Vector3 paperPosition = bm.GetRandomPosition(paper);
                bm.AddObjectToBoardAtPosition(paper, paperPosition);
            }
         }
         
         public int GetPaperObjectsLeft()
        {
            GameObject[] papers = GameObject.FindGameObjectsWithTag("Paper");
            return papers.Length;
        }

        public override bool CheckLevelOver()
        {
            // Player has closed 5 brackets or hit 5 wrong brackets
            if (GameManager.instance.GetPlayerPoints() >= 10 || GameManager.instance.GetPlayerPoints() <= -5)
            {
                return true;
            }
            return false;
        }

        public override void SetLevelText()
        {
            int playerPoints = GameManager.instance.GetPlayerPoints();
            int coworkerPoints = GameManager.instance.GetAntiPlayerPoints();
        }
    }
}

