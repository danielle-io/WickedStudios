using UnityEngine;
using System.Collections;
using UnityEngine.UI;   //Allows us to use UI.
using UnityEngine.SceneManagement;

namespace WickedStudios
{
    // Player inherits from MovingObject, 
    // our base class for objects that can move, 
    // Enemy also inherits from this.
    public class Player : MovingObject
    {
        public float restartLevelDelay = 1f;

        public AudioClip moveSound1;
        public AudioClip moveSound2;

        public AudioClip gameOverSound;
        public int pointsPerItems = 1;

        public Text playerScoreText;

        //Used to store a reference to the Player's animator component.
        private Animator animator;                  
        private static int points;     
                           
        #if UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

        private Vector2 touchOrigin = -Vector2.one; 

        //Used to store location of screen touch origin for mobile controls.
        #endif

        //Start overrides the Start function of MovingObject
        protected override void Start()
        {
            //Get a component reference to the Player's animator component
            //animator = GetComponent<Animator>();
            
            //Call the Start function of the MovingObject base class.
            base.Start();
        }

        //This function is called when the behaviour becomes disabled or inactive.
        private void OnDisable()
        {
            //When Player object is disabled, store the current local food total in the GameManager so it can be re-loaded in next level.
            GameManager.instance.playerItemPoints = points;
        }


        private void Update()
        {
            int horizontal = 0;
            int vertical = 0;

            #if UNITY_STANDALONE || UNITY_WEBPLAYER

            horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
            vertical = (int) (Input.GetAxisRaw ("Vertical"));

            //Check if moving horizontally, if so set vertical to zero.
            if (horizontal != 0)
            {
                vertical = 0;
            }

            #endif //End of mobile platform dependendent compilation section started above with #elif
            //Check if we have a non-zero value for horizontal or vertical
            if (horizontal != 0 || vertical != 0)
            {
                // Call AttemptMove passing in the generic parameter Wall,
                //  since that is what Player may interact with if 
                // they encounter one (by attacking it)
                //Pass in horizontal and vertical as parameters 
                // to specify the direction to move Player in.
                AttemptMove<Wall>(horizontal, vertical);
            }
        }

        // AttemptMove overrides the AttemptMove function in the base class MovingObject
        // AttemptMove takes a generic parameter T which for Player 
        // will be of the type Wall, it also takes integers for 
        // x and y direction to move in.
        protected override void AttemptMove<T>(int xDir, int yDir)
        {
            //playerScoreText.text = "Collected: " + points;

            base.AttemptMove<T>(xDir, yDir);

            //Hit allows us to reference the result of the Linecast done in Move.
            RaycastHit2D hit;

            // If Move returns true, meaning Player 
            // was able to move into an empty space.
            if (Move(xDir, yDir, out hit))
            {
                // Call RandomizeSfx of SoundManager to 
                // play the move sound, passing in two audio clips to choose from.
                //SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
            }
        }


        // OnCantMove overrides the abstract function OnCantMove in MovingObject.
        // It takes a generic parameter T which in the case of Player 
        // is a Wall which the player can attack and destroy.
        protected override void OnCantMove<T>(T component)
        {

            ////Set hitWall to equal the component passed in as a parameter.
            //Wall hitWall = component as Wall;


            ////Set the attack trigger of the player's animation controller in order to play the player's attack animation.
            //animator.SetTrigger("playerChop");
        }

        public void SetPoints(int num)
        {
            points += 1;
            //playerScoreText.text = "Collected: " + points;

        }

        // OnTriggerEnter2D is sent 
        // when another object enters a 
        // trigger collider attached to this object 
        // (2D physics only)
        private void OnTriggerEnter2D(Collider2D collisionItem)
        {
            Debug.Log("Triggered Collision in Player");

        }


        //Restart reloads the scene when called.
        private void Restart()
        {
            //Load the last scene loaded, in this case Main, the only scene in the game. And we load it in "Single" mode so it replace the existing one
            //and not load all the scene object in the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }
}

