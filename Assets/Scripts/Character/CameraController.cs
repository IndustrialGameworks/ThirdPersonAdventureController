using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject rig; //where the camera is focussed

    private Vector3 offset;

    float horizontalMouse;
    float verticalMouse;

    // Use this for initialization
    void Start () {
        rig = GameObject.Find("CameraRig");
    }
	
	// Update is called once per frame
	void Update () {
        GetMouseInput();
        CameraRotate();
    }

    void CameraRotate () //rotates the camera
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(rig.transform.position, Vector3.up, 50 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(rig.transform.position, Vector3.down, 50 * Time.deltaTime);
        }
        else if (Input.GetMouseButton(1)) //rotates camera on right mouse button
        {
            transform.RotateAround(rig.transform.position, Vector3.down, -horizontalMouse * 150 * Time.deltaTime);
        }
    }

    void GetMouseInput()
    {
        horizontalMouse = Input.GetAxisRaw("Mouse X");
        verticalMouse = Input.GetAxisRaw("Mouse Y");
        //Debug.Log(horizontalMouse);
        //Debug.Log(verticalMouse);
    }
}
