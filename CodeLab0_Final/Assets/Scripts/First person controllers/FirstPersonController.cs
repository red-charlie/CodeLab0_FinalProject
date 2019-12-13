using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
   public GameObject SceneChanger;
    public KeyCode ForwardButton; //normal wasd controller stuff
    public KeyCode BackButton;
    public KeyCode StrafeLeft;
    public KeyCode StrafeRight;

    public KeyCode JumpButton;
    public float MovementSpeed = 10f; //how fast to move
    //public float jumpForce = 100f; //how high this dude jumps
    //public Transform Player;
    
    public GameObject Timer;
    public GameObject Dog;
    public AudioSource Whistle;


    Rigidbody rb;
   SceneChangeScript  Sc;
    
    


    void Start()
    {
      rb = GetComponent<Rigidbody>();
      Sc = SceneChanger.GetComponent<SceneChangeScript>(); //get the scene changer script
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.Space))
       {
          if(UIStoryScript.IsOver ==true)
          {
             GameManager.GameComplete = true;
             GameManager.ResetEntireGame();
            
             //end the game
            Sc.ChangeScene();


          }
       }
       if(Input.GetKeyDown(KeyCode.E))
       {
          if (GameManager.WhistleFound == true && DogTimerScript.TimeOut == false) //if you have the whistle and the timer isn't over
          {
             //blow whistle
             Whistle.Play(); //plauy the whistle sound
             UIStoryScript.WhistleUse(); //change the text
             Timer.SetActive(true); //start the timeer
             Dog.SetActive(true); //release the hound



          }
       }
        //CameraLook(); //Move the camera based on mouse - moved this to it's own script because I was getting confused

        #region WASD Controller
        
        Vector3 ForwardDirection = transform.forward;  //the player's relative forward 
        Vector3 RightDirection = transform.right; //the players relative right 
        Vector3 CurrentVelocity = rb.velocity; //the current velocity

       

        if (Input.GetKey(ForwardButton)){
           //rb.velocity = new Vector3 (0,0,MovementSpeed); //altering these because they don't account for rotation
           rb.velocity = ForwardDirection * MovementSpeed; //Move forward at the movement speed float
        }

        if (Input.GetKey(BackButton)){
           // rb.velocity = new Vector3 (0,0,-MovementSpeed);
           rb.velocity =  ForwardDirection * -MovementSpeed;
        }

        if (Input.GetKey(StrafeLeft)){
           // rb.velocity = new Vector3 (MovementSpeed,0,0);
           rb.velocity = RightDirection * -MovementSpeed;

        }

        if(Input.GetKey(StrafeRight)){
           // rb.velocity = new Vector3 (-MovementSpeed,0,0);
           rb.velocity = RightDirection * MovementSpeed;
        }

        else if (Input.GetKeyUp(StrafeLeft)    || 
                 Input.GetKeyUp(ForwardButton) || 
                 Input.GetKeyUp(StrafeRight)   || 
                 Input.GetKeyUp(BackButton     ))
        {
                // if (Player.position.y <= 1){
           rb.velocity = new Vector3 (0,0,0); // if no input from controls please stop
           
                // }
        }
        #endregion

        // #region jump Removing the jump, it isn't used ever
        // if (Input.GetKeyDown(JumpButton))
        // {
        //     rb.AddForce (new Vector3 (0, jumpForce, 0)); 
        //     print("I am jumping");
        // }
        // #endregion
        
    }

    void OnTriggerEnter (Collider other)
    {
       if(other.gameObject.name =="Dog")
       {
          AudioSource yay = gameObject.GetComponent<AudioSource>();
          yay.Play(); //play the yay sound
       }
    }


}
