using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    Rigidbody rb;
    float MovementRange = 100;
    //public Collider Trigger;
    public GameObject FPPlayer;
    public GameObject self;
    public GameObject Timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3 (   Random.Range(MovementRange,-MovementRange),
                                    0,
                                    Random.Range(MovementRange,-MovementRange)
                                ));
    }

    void OnTriggerEnter (Collider other)
    {
        AudioSource Bark = gameObject.GetComponent<AudioSource>();
        Bark.Play();
    
       if(other.gameObject == FPPlayer)
       {
           //collect the dog
           GameManager.DogCaught = true;
           UIStoryScript.SuccessDogCatch();
           Timer.SetActive(false);
           self.SetActive(false); //turn off myself
           

       }
    }
}
