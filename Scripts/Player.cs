using UnityEngine;

public class Player : MonoBehaviour
{
    //Accessing the SpriteRederer object
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; //declaring an array of Sprite to store sprites
    private int spriteIndex; //to keep track or the sprites

    //setting up variables for the birds movement/acceleration/physics like gravity and strenght!
    private Vector3 direction;      //variable to store a direction for the bird.     
    public float gravity = -9.8f;   //the gravity- a unity physics that follow the laws of gravity
    public float strength = 5f;     //a strengt of how strong the bird will go up


    //declare the Awake method to load in early initialization
    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  //inside the awake method we assined the SpriteRenderer component of the Player object to a variable.
    }

    private void OnEnable(){
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    //calling the start method for the first frame 
    public void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f ); //function to repeatedly call a method where nameof, every 0.15 second
    }

    //Update function this function runs to update a movement/action for the class or for the Player Object
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //Checking if the Space key in the keyboard and the left click in the mouse is being clicked
        {
            direction = Vector3.up * strength; //if Space bar or mouse left click is being clicked, the direction of the Player Object will go up in y axis with strenght/speed of the assigned value "strenght"
        }

        if(Input.touchCount > 0) //for touch function, calling a touch count oject, used for mobile devices!
        {
            Touch touch = Input.GetTouch(0); //Getting the first touch

            if(touch.phase == TouchPhase.Began) //checks if the touch has began
            {
                direction = Vector3.up * strength; //then the player object will go to the y axis
            }
        }

        //setting movement/gravity to have a fix and smooth movement in every frame and value of the computer's frame rate
        direction.y += gravity * Time.deltaTime;  //ensure the movement of the Player object moves smoothly in every frame rate/frames
        transform.position += direction * Time.deltaTime; //updating position according to the current direction regardless of the frame rate

    }

    //creating an animation method to cycle through the indexes of the Sprites 
    private void AnimateSprite()
    {
        spriteIndex++; // to increment sprite index by 1 every time the AnimateSprite function is being called

            if(spriteIndex >= sprites.Length) //checks if the spriteIndex is greater or equal to the sprite array length
        {
            spriteIndex = 0; //if the condition is true then the sprites will go back from index 0
        }

        spriteRenderer.sprite = sprites[spriteIndex]; //assigning the SpriteRender component value to be equal to the indexes of the sprites variable
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Obstacle"){
            FindObjectOfType<GameManager>().GameOver();
        }else if(other.gameObject.tag == "Scoring"){
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
