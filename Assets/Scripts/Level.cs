using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WickedStudios
{
    // Abstract class used as the base for all levels.
    public abstract class Level : MonoBehaviour
    {
        // Given a BoardManager, sets up the game board for this level.
        public virtual void SetupLevel()
        {
        }

        // Returns true if the level is over.
        public virtual bool CheckLevelOver()
        {
            return true;
        }

        public virtual void SetLevelText()
        {
        }
    }
}
