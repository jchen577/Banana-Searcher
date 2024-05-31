// Referenced this https://youtu.be/xJJ_26lnTK0?si=3rPJuaZrNqVQAQVi
// And and clickToMove 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject LongCube;

    // Update is called once per frame
    void Update()
    {
	// Using a similar method as clickToMove for the bananas
		if (Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Input.mousePosition.y < 1200)
			{
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					// Place down a randomly rotated block
					// int randRotate = Random.Range(0, 180);
					// Quaternion rot = Quaternion.Euler(0, randRotate, 0);

					Quaternion rot = Quaternion.Euler(0, 0, 0); // No rotation
					Instantiate(LongCube, hit.point, rot);
				}
			}
		}
	}
}
