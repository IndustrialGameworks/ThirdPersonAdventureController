using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public GameObject playerCamera;
    public GameObject characterController;
    NavMeshAgent agent;

    float horizontalMovement;
    float verticalMovement;
    public float movementSpeed = 25;
    public float rotationSpeed = 10;

    Vector3 mouseClickLocation; //the value fed into ClickLocation() from MousePointer

	// Use this for initialization
	void Start () {
        playerCamera = GameObject.Find("Main Camera");
        characterController = GameObject.Find("CharacterController");
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        ManualMovement();
	}

    void ManualMovement()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        if (horizontalMovement != 0 || verticalMovement != 0) //if manual controls initiated, stops the nav mesh agent trying to get to its location
        {
            agent.isStopped = true;
        }

        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0.0f; //gets rid of the cameras changed y value

        Vector3 right = playerCamera.transform.right;
        right.y = 0.0f;

        
       // Debug.Log (horizontalMovement);
        //Debug.Log(verticalMovement);

        characterController.transform.position += (Vector3.Normalize(forward * (verticalMovement) + right * (horizontalMovement)) * Time.deltaTime * movementSpeed);

        CharacterRotation(forward, right); //passes in the camera calculated forward/right vectors
        
    }

    public void ClickMovement(Vector3 clickedLocation) //takes the pointer location and moves character to that location
    {
        //mouseClickLocation = clickedLocation;
        agent.destination = clickedLocation;
        agent.isStopped = false; //reinitiates agent if it was stopped by player input
        //Debug.Log("should have moved on mouse click");
    }

    void CharacterRotation(Vector3 forward, Vector3 right) //passes in the camera orientated forward and right vectors, then uses them rotate the character according to directional input axis
    {
       if (horizontalMovement > 0)
        {
            transform.rotation = Quaternion.LookRotation(right);
        }
       if (horizontalMovement < 0)
        {
            transform.rotation = Quaternion.LookRotation(-right);
        }
       if (verticalMovement > 0)
        {
            transform.rotation = Quaternion.LookRotation(forward);
        }
        if (verticalMovement < 0)
        {
            transform.rotation = Quaternion.LookRotation(-forward);
        }
        if (verticalMovement > 0 && horizontalMovement > 0)
        {
            Vector3 combinedVector = forward + right;
            transform.rotation = Quaternion.LookRotation(combinedVector);
        }
        if (verticalMovement < 0 && horizontalMovement < 0)
        {
            Vector3 combinedVector = -forward + -right;
            transform.rotation = Quaternion.LookRotation(combinedVector);
        }
        if (verticalMovement > 0 && horizontalMovement < 0)
        {
            Vector3 combinedVector = forward + -right;
            transform.rotation = Quaternion.LookRotation(combinedVector);
        }
        if (verticalMovement < 0 && horizontalMovement > 0)
        {
            Vector3 combinedVector = -forward + right;
            transform.rotation = Quaternion.LookRotation(combinedVector);
        }
    }
}
