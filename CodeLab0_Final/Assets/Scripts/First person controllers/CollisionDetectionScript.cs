using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionScript : MonoBehaviour
{
  
    //references to triggers
    public GameObject ExitMorning;
    public GameObject EnterHarrisHome;
    public GameObject EnterOtherHome;
    public GameObject EnterStore;
    public GameObject EnterHome;
    
    public ParticleSystem Sadness;
    public ParticleSystem Joy;

    void Start ()
    {
        //NarrativePanel.SetActive(true);
        ExitMorning.SetActive(true); //the beginning stuff should all be on
        EnterHarrisHome.SetActive(true); //harri's home is ready
        EnterOtherHome.SetActive(true); //the neighbors home is also ready
        EnterStore.SetActive(true); //the store too
        EnterHome.SetActive(false); //this shouldn't be on because you're already home




    }

    public void OnTriggerEnter (Collider other)

    {
        print("I have collided " + other.gameObject.name);

        
        if(other.gameObject == ExitMorning)
        {
            //Leaving the house in the beginning
            ExitMorning.SetActive(false);
            EnterHome.SetActive(true);

            
        }

        if(other.gameObject == EnterHome)
        {
        
            //Enterhome pathways
            if(GameManager.HarriTalked == true || GameManager.WhistleFound == true)
            {
                //you just went back to bed you coward
               UIStoryScript.AbandonedTheMission();

            }

            if(GameManager.DogCaught == true)
            {
                if(UIStoryScript.IsOver ==true)
                {
                    UIStoryScript.SuccessDogReturn();
                    UIStoryScript.IsOver = true;

                 }
                 else{

                     UIStoryScript.YouStole();
                 } 

            }
            

        }

        if(other.gameObject == EnterHarrisHome)
        {
            
            if (GameManager.HarriTalked ==false){

            UIStoryScript.EnterHarri1();
            Sadness.Play();

            GameManager.HarriTalked = true;
            }

            if(GameManager.DogCaught == true)
            {
                //congrats you did it
                UIStoryScript.SuccessDogReturn();
                Joy.Play();
                GameManager.DogReturned = true;

            }

        }

        if(other.gameObject == EnterStore)
        {
            //Store pathways
            if(GameManager.HarriTalked == true)
            {
              //get dog whistle
              GameManager.WhistleFound = true;
              UIStoryScript.EnterStore();
            }

            // if(GameManager.HarriTalked == false)
            // {
            //     //fail state
               
            // }
        }

        if(other.gameObject == EnterOtherHome)
        {
            //other home pathways
            if(GameManager.HarriTalked == true)
            {
                if(GameManager.WhistleFound == true)
                {
                    //why are you here? 
                    UIStoryScript.EnterWrongHouse();
                }

                if (GameManager.WhistleFound == false)
                {
                    //I'm not the store
                    UIStoryScript.EnterWrongHouse();
                }
            }

            if(GameManager.HarriTalked == false)
            {
                //fail
                UIStoryScript.EnterWrongHouse();
                

            }
            if (GameManager.DogCaught ==true)
            {
                UIStoryScript.WrongOwner();

            }
        }


        
    }
}
