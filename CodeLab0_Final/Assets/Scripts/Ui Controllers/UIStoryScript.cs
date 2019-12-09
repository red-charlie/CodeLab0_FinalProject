using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIStoryScript : MonoBehaviour
{
    static public bool IsOver = false;
    static public Text NarrativeText; //the narrative text box
    public GameObject NarrativePanel;
    static public string OpeningText; //first line of text.
    static public string StoreText;
    static public string HarriText;
    static public string WrongHouseText;
    static public string YouStoleText;
    static public string WrongOwnerText;
    static public string AbandonText;
    static public string WhistleText;
    static public string WhistleAgainText;
    static public string SuccessDogCatchText;
    static public string SuccessReturnText;

   



    // Start is called before the first frame update
    void Start()
    {
        NarrativeText = NarrativePanel.GetComponent<Text>();
        IsOver = false;

        OpeningText = "What is that noise? It's coming from Harri's house. I should probably take a look. ";
        StoreText ="+1 Dog Whistle added to your inventory. Go outside and press E to use it!";
        HarriText ="Oh man, Harri's Dog is missing. Maybe I can stop by the store and find a dog whistle. ";
        WrongHouseText ="This isn't Harri's house. Cool guess you don't care about Harri. You Lost. Press Space to Try again.";
        YouStoleText ="You just stole Harri's dog. I hope you feel about about it you monster. You Lost. Press Space to Try again.";
        WrongOwnerText ="You returned Harri's dog to the wrong house. Are you kididng me? You Lost. Press Space to Try again.";
        AbandonText ="You Abandoned Harri and went to sleep. Whatever Harri sucks. You Lost. Press Space to Try again.";
        WhistleText = "You have blown the whistle. You have 30 seconds to catch the dog";
        WhistleAgainText= "Your time has run out, the dog has given up, and Harri doesn't trust you anymore! You Lost. Press Space to Try again.";
        SuccessDogCatchText ="You caught Harri's Dog! Return it!";
        SuccessReturnText = "You returned Harri's dog! Congratulations! Return home to rest (space bar) to complete your day!";

        if(GameManager.GameComplete == false)
        {
            NarrativeText.text = OpeningText; //Opening text should show at the beginning of the game
        }
    }


    static public void EnterHarri1()
    {
        NarrativeText.text = HarriText;
    }

    static public void EnterWrongHouse()
    {
        NarrativeText.text = WrongHouseText;
        IsOver = true;
    }
    static public void YouStole ()
    {
        NarrativeText.text = YouStoleText;
        IsOver = true;
    }
    
    static public void WrongOwner ()
    {
        NarrativeText.text = WrongOwnerText;
        IsOver = true;
    }

    static public void AbandonedTheMission ()
    {
        NarrativeText.text = AbandonText;
        IsOver = true;
    }

    static public void SuccessDogCatch ()
    {
        NarrativeText.text = SuccessDogCatchText;
    }

    static public void SuccessDogReturn ()
    {
        NarrativeText.text = SuccessReturnText;
    }
    static public void EnterStore()
    {
        NarrativeText.text = StoreText;

    }

    static public void WhistleUse ()
    {
        NarrativeText.text = WhistleText;
    }
    
    static public void TimeOut ()
    {
        NarrativeText.text = WhistleAgainText;
        IsOver = true;
    }
    

}
