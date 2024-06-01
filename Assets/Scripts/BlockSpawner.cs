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
		// note: consider having a cooldown for placing blocks -ashley
		// probably use a time function or smth, theres probably a standard to it rather than just make a counter var and inc that lol

		// Show preview of block
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.mousePosition.y < 1200)
		{
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				// Show preview of block at mouse
				// hit.point -= new Vector3(1.365f, 0f, -0.479f);
				preview.transform.position = hit.point;

				//at button press, add 90 or sub 90 from rotation
				if (Input.GetMouseButtonDown(2)) // consider changing to left and right arrow keys
				{
					preview.transform.Rotate(0f, 90f, 0f, Space.Self); // should be using euler degrees
				}

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
