using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigTracking : MonoBehaviour {

    public GameObject player; //where the camera is focussed
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("PlayerCharacter");
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        TrackPlayer();
    }

    void TrackPlayer()
    {
        transform.position = player.transform.position + offset;
    }
}
