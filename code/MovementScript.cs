using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {

    //-- here were declare the variables we will use
    public float movementSpeed = 10.0f; //-- making it public will make it appear in the Unity interface
    public float rotationSpeed = 3.0f;
    CharacterController myController;
    Vector2 rotation = Vector2.zero;

    void Start(){
        //-- first, we tell our script to find the Character Controller component in the current Game Object
        myController = GetComponent<CharacterController>();
    }

    void Update(){
        //-- we calculate the amount of forward movement based on the current direction
        Vector3 forwardDirection = transform.TransformDirection(Vector3.forward) * Input.GetAxis("Vertical");

        //-- we calculate the amount of lateral movement based on the current direction
        Vector3 lateralDirection = transform.TransformDirection(Vector3.right) * Input.GetAxis("Horizontal");

        //-- we add the two previous movement, and make the Y component 0, so that we don't fly away!
        Vector3 overallDirection = new Vector3(lateralDirection, 0, forwardDirection);

        //-- finally we move the character controller in the overall direction, multiplied by our speed variable
        //-- the Time.deltaTime variable accounts for different frame rates on different devices
        myController.Move(overallDirection * movementSpeed * Time.deltaTime);


        //-- and now we rotate based on the mouse position
        rotation.x += Input.GetAxis("Mouse Y");
        rotation.y += Input.GetAxis("Mouse X");
        transform.eulerAngles = (Vector2)rotation * rotationSpeed;
    }
}