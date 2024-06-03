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

        if (newX > -6 && newX < 30 && newZ > -15 && newZ < 20)
        {
            transform.position = new Vector3(newX, transform.position.y, newZ);
        }
        
        // notes: camera should have limits so you cant move it tooo far away from play area -ashley
        }
}