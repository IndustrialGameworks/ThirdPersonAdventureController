using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMarker : MonoBehaviour {

    public void ChangePosition(Vector3 mouseLocation)
    {
        transform.position = new Vector3(mouseLocation.x, mouseLocation.y, mouseLocation.z);
    }
}
