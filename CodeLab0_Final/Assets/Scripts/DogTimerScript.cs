using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DogTimerScript : MonoBehaviour
{
    public float timer = 30f;
    public Text TimerText;
    public GameObject self;

    // Start is called before the first frame update
 void Start ()
 {
      InvokeRepeating("UpdateText", 1, 1); //invoke this every one second
 }

    // Update is called once per frame
    void Update()
    {
        //timer -= Time.deltaTime;
       
        //UpdateText();

        if (timer <= 0){
            UIStoryScript.TimeOut(); //time runs out and the game ends
           self.SetActive(false); //turn myself off
        }
        
    }

    void UpdateText ()
    {
        timer --;
        TimerText.text = (""+timer); //take a second away and update the text
    }
}
