using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryScript : MonoBehaviour
{
    public GameObject credits;
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.GameComplete == true)
        {
            mainMenu.SetActive(false);
            credits.SetActive(true);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
