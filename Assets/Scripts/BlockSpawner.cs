// Referenced this https://youtu.be/xJJ_26lnTK0?si=3rPJuaZrNqVQAQVi
// And and clickToMove 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
	// Place and Pre list should be in the same order 
	public List<GameObject> prefabPlaceList = new List<GameObject>();
	public List<GameObject> prefabPreList = new List<GameObject>();
	private GameObject preview;
	private int randIdx;
	private float timer;

	void Start(){
		// Randomize current selected block
		randIdx = Random.Range(0, prefabPlaceList.Count - 1);
		preview = Instantiate(prefabPreList[randIdx], transform.position, transform.rotation);
	}

    // Update is called once per frame
    void Update()
    {
		// Timer that controls cooldown of placing down blocks
		if (timer > -1){ // Don't want to cause an overflow if the timer doesn't get reset
			timer -= Time.deltaTime;
		}

		// Locate mouse pointer in the world
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.mousePosition.y < 1200)
		{
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				// Show preview of the block at mouse
				preview.transform.position = hit.point;

				//at button press, add 90 or sub 90 from rotation
				//if (Input.GetMouseButtonDown(2)) // consider changing to left and right arrow keys
				//{
				//	preview.transform.Rotate(0f, 90f, 0f, Space.Self); // uses euler degrees
				//}
				if (Input.GetKeyDown("q"))
				{
					preview.transform.Rotate(0f, 90f, 0f, Space.Self);
				}
				if (Input.GetKeyDown("e"))
				{
					preview.transform.Rotate(0f, -90f, 0f, Space.Self);
				}


				// Place block
				if (Input.GetMouseButtonDown(1) && timer < 0)
				{
					Destroy(preview);
					Quaternion rot = Quaternion.Euler(preview.transform.eulerAngles);
					Instantiate(prefabPlaceList[randIdx], hit.point, rot);
					//Debug.Log("Obj placed at " + hit.point);


					// Select new shape to place next
					randIdx = Random.Range(0, prefabPlaceList.Count);
					preview = Instantiate(prefabPreList[randIdx], transform.position, transform.rotation);
					timer = 2; // is equal to seconds
				}
			}
		}
	}
}
