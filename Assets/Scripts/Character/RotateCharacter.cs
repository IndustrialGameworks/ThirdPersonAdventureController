using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
    public void CharacterRotationForward(Vector3 forward)
    {
        transform.rotation = Quaternion.LookRotation(forward);
    }
    public void CharacterRotationBackward(Vector3 forward)
    {
        transform.rotation = Quaternion.LookRotation(-forward);
    }
    public void CharacterRotationLeft(Vector3 right)
    {
        transform.rotation = Quaternion.LookRotation(-right);
    }
    public void CharacterRotationRight(Vector3 right)
    {
        transform.rotation = Quaternion.LookRotation(right);
    }
}
