using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void QuitTheGame(){
        Application.Quit();
        print("I have Quit the Game.");
    }
}
