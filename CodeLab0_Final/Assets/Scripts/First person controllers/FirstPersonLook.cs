using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour

{       //I'd like to dedicate this entire script to that one guy on youtube who has a ton of FPS code videos. I watched all of them and mushed them together to make this.
    public string MouseXInputName; //The string of the mouse input in unity found it under project settings
    public string MouseYInputName;
    public float MouseSensitivity = 100; //How fast the camera moves 
    float XAngle; //x angle of the camera to stop it at 90
   // public GameObject Player;
   public Transform Player;

    void Start()
    {
        XAngle = 0f;
    }

    
    void Update()
    {
      CameraRotation();//putting it in it's own function-- the guy on youtube did it, so this way I don't get confused when I look at his code

    }

    public void CameraRotation(){ // as someone who spent a lot of time looking this up, may I just say, that rotations are stupid sometimes, and what I thought would take like ten minutes took all day
        float MouseX =
             Input.GetAxis(MouseXInputName) 
            * MouseSensitivity 
            * Time.deltaTime; //combining the mouse position with the mouse sensitivity over time

        float MouseY = 
            Input.GetAxis(MouseYInputName) 
            * MouseSensitivity 
            * Time.deltaTime; 

       // move the camera to the new position/rotation
       //Vector3 newPosition = new Vector3 (MouseX, MouseY,0);
      #region  clamping it so that you can't do backflips

        


         XAngle += MouseY; //value of Xangle 

         if (XAngle >= 90) //If the camera is looking straight up 
         {
             XAngle = 90; //keep it at 90
             MouseY= 0; //don't add more movement

             //Adding a clamp here that I found helpful because the camera would sometimes start at something other than 0?
             float XclampValue = 270f;
             Vector3 eulerRotation = transform.eulerAngles; // get the euler rotation
             eulerRotation.x = XclampValue; //keep it at 270
             transform.eulerAngles = eulerRotation;
         }
         else if (XAngle <= -90)// if the camera is looking straight down
         {
             XAngle = -90; //keep it looking down
             MouseY = 0; //don't add more movement
             float XclampValue = 90f;
             Vector3 eulerRotation = transform.eulerAngles; // get the euler rotation
             eulerRotation.x = XclampValue; //keep it at 90
             transform.eulerAngles = eulerRotation;  
         }

       #endregion

       //Rotating the Camera  in the Y and the player body in the X

      // transform.Rotate(-transform.right * MouseY); //Rotates based off the Mouse Y #
        
        transform.Rotate(Vector3.left * MouseY); //rotates with mouse Y

        //transform.Rotate(transform.up * MouseX); // does not rotate side to side correctly-- I need to rotate player parent
        //Player.transform.Rotate (0,MouseX,0); //just tilts it

        Player.Rotate (Vector3.up * MouseX);
        
        //couple of tests, trying to figure out how this actually works
        //transform.Rotate(newPosition);
        //transform.Rotate(transform.up * MouseX);
        //transform.Rotate(transform.left*MouseX );
        //transform.Rotate(transform.right * MouseY);
        //print ("This is my top rotation " + Transform.up);

        

    }
}
