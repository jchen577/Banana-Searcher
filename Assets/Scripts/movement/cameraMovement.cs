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

        float newX = transform.position.x + xAxisValue;
        float newZ = transform.position.z + zAxisValue;

        // Limit the camera movement (to keep the game space on screen at all times)
        if (newX > -6 && newX < 30 && newZ > -15 && newZ < 20)
        {
            transform.position = new Vector3(newX, transform.position.y, newZ);
        }
        
        }
}