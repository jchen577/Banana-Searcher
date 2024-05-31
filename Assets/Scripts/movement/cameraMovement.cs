using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public int Speed = 50;

    void Update()
    {
        float xAxisValue = Input.GetAxis("Vertical") * -Speed;
        float zAxisValue = Input.GetAxis("Horizontal") * Speed;

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + zAxisValue);
    }
}