using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public string NextScene; //the variable for the scene to change to

  public void ChangeScene(){ //function called by the button
    SceneManager.LoadScene(NextScene);//load Next scene 
  }


}
