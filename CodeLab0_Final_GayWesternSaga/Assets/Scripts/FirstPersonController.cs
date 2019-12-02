using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public KeyCode ForwardButton;
    public KeyCode BackButton;
    public KeyCode StrafeLeft;

    public KeyCode StrafeRight;

    public float MovementSpeed = 10f;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region WASD Controller
        if (Input.GetKeyDown(ForwardButton)){
           rb.velocity = new Vector3 (0,0,MovementSpeed);
        }

        if (Input.GetKeyDown(BackButton)){
            rb.velocity = new Vector3 (0,0,-MovementSpeed);
        }

        if (Input.GetKeyDown(StrafeLeft)){
            rb.velocity = new Vector3 (MovementSpeed,0,0);

        }

        if(Input.GetKeyDown(StrafeRight)){
            rb.velocity = new Vector3 (-MovementSpeed,0,0);
        }
        #endregion
        
    }
}
