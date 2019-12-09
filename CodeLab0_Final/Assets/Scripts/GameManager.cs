using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public bool GameComplete = false;//whether or not you have completed the game\
    static public bool HarriTalked = false;
    static public bool WhistleFound = false;
    static public bool DogCaught = false;

    static public bool DogReturned = false;

    // public GameObject MainMenu;
    // public GameObject Credits;




    
    void Start()
    {
        int numGameManagers = FindObjectsOfType<GameManager>().Length; // making a collection of all game managers because I kept getting a bunch of music. 
     if (numGameManagers != 1)
     {
         Destroy(this.gameObject);
     }
        DontDestroyOnLoad(this); //keeps it from scene to scene

      
    }

   

    public void CompleteTheGame()
    {
        GameComplete = true; //you have completed the game

    }

    //Used to check if you had completed the game, but I found a better way of doing it.
    // public void MenuCheck(){
    //     if (GameComplete == true)
    //     {
    //         MainMenu.SetActive(false);
    //         Credits.SetActive(true);

    //     }
    // }
    public void ResetEntireGame() //resets everything to it's original state

    {
        if(GameComplete == true){
        GameComplete = false;
        HarriTalked = false;
        WhistleFound = false;
        DogCaught = false;
        DogReturned = false;
        print (" I have reset the game... Everything should be playable again");
        UIStoryScript.IsOver = false;
        }

    }
}
