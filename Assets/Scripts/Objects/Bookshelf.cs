using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookshelf : MonoBehaviour
{

    bool playerPresent = false;

    // Update is called once per frame
    void Update()
    {
        if (playerPresent)
        {
            Action();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("entered");
            playerPresent = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("exit");
            playerPresent = false;
        }
    }

    void Action()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("an old book case, nothing special");
        }
    }
}
