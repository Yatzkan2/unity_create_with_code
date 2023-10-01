using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Getting user direction inputs
        verticalInput = Input.GetAxis("Vertical");
        if(verticalInput != 0)
            horizontalInput = Input.GetAxis("Horizontal");
        else
            horizontalInput = 0;


        //transform.Translate(0, 0, 1); moves the object one unit on the z axes every frame.
        //transform.Translate(Vector3.forward) the same as the line above, but much more programmer freindly.

        //Move vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput); //dealteTime explanation: https://medium.com/star-gazers/understanding-time-deltatime-6528a8c2b5c8
        //Turning the vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
