using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour {

    public Vector3 positionOfMouse;

    public Camera cam;

    public GameObject marker;
    public GameObject playerCharacter;
    MouseMarker markerScript;
    PlayerController playerScript;

    // Use this for initialization
    void Start () {
		cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        marker = GameObject.Find("MouseMarkerSphere");
        playerCharacter = GameObject.Find("PlayerCharacter");
        markerScript = marker.GetComponent<MouseMarker>();
        playerScript = playerCharacter.GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        FindPointerLocation();
        PointerInput();
    }

    void FindPointerLocation()
    {
        Vector3 cameraLocation = cam.transform.position; //retrieve cameras location and saves it to a variable

        RaycastHit hit; //raycasthit stores information regarding where a raycast ends
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 100))
        { //if the raycast hits the terrain
            positionOfMouse = hit.point; //the endpoint of the raycast corresponds to mouse position relative to terrain
            markerScript.ChangePosition(positionOfMouse);
            //Debug.Log(positionOfMouse); //needs to be finalised for debug mode
        }
        else
        {
            Debug.Log("Raycast cannot find terrain");//debug error message returned if raycast cant find terrain
        }
    }

    void PointerInput()
    {
        if (Input.GetMouseButton(0)) //for movement/interaction
        {
            playerScript.ClickMovement(positionOfMouse); //feeds mouse pointer location into PlayerController
            //Debug.Log("Left Click");
        }
    }

}
