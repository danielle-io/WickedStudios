using UnityEngine;

namespace WickedStudios
{
    // Abstract class used as the base for all levels.
    public abstract class Level : MonoBehaviour
    {
        // Given a BoardManager, sets up the game board for this level.
        public virtual void SetupLevel(BoardManager bm)
        {
        }

        // Returns true if the level is over.
        public virtual int CheckLevelOver()
        {
            return 0;
        }

        public virtual void SetLevelText()
        {
        }

        public virtual string GetNextScene()
        {
            return "";
        }

    }
}
