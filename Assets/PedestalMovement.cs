using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalMovement : MonoBehaviour
{
    public int rotateSpeed;

    void Update ()
    {
        transform.Rotate (0,rotateSpeed*Time.deltaTime, 0); //rotates 50 degrees per second around z axis
    }
}
