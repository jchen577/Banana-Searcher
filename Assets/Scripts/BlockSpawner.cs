// Referenced this https://youtu.be/xJJ_26lnTK0?si=3rPJuaZrNqVQAQVi
// And and clickToMove 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject PlaceObj;
	public GameObject PreviewObj;
	private GameObject preview;

	void Start(){
		preview = Instantiate(PreviewObj, transform.position, transform.rotation);
	}
    // Update is called once per frame
    void Update()
    {
		// Show preview of block
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.mousePosition.y < 1200)
		{
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				// Show preview of block at mouse
				preview.transform.position = hit.point;

				// Place block
				if (Input.GetMouseButtonDown(1))
				{
					// Place down a randomly rotated block
					// int randRotate = Random.Range(0, 180);
					// Quaternion rot = Quaternion.Euler(0, randRotate, 0);

					Quaternion rot = Quaternion.Euler(0, 0, 0); // No rotation
					Instantiate(PlaceObj, hit.point, rot);
					//Debug.Log("Obj placed at " + hit.point);
				}
			}
		}
	}
}
