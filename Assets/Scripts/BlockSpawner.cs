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
	private List<GameObject> placedBlocks = new List<GameObject>();

	void Start(){
		gameObject.SetActive(false); // Game object not active until start button is pressed and enables it
		// Randomize current selected block
		randIdx = Random.Range(0, prefabPlaceList.Count - 1);
		preview = Instantiate(prefabPreList[randIdx], transform.position, transform.rotation);
	}

    // Update is called once per frame
    void Update()
    {
		if (gameObject.activeSelf)
		{
			// Timer that controls cooldown of placing down blocks
			if (timer > -1)
			{ // Don't want to cause an overflow if the timer doesn't get reset
				timer -= Time.deltaTime;
			}

			// Locate mouse pointer in the world
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Input.mousePosition.y < 1200)
			{
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					// Move preview of the block to mouse
					preview.transform.position = hit.point;


					// Middle Mouse Click to rotate +90 degrees
					if (Input.GetMouseButtonDown(2)) // consider changing to left and right arrow keys
					{
						preview.transform.Rotate(0f, 90f, 0f, Space.Self); // uses euler degrees
					}
					// Q to rotate +90 degrees
					if (Input.GetKeyDown("q"))
					{
						preview.transform.Rotate(0f, 90f, 0f, Space.Self);
					}
					// E to rotate -90 degrees
					if (Input.GetKeyDown("e"))
					{
						preview.transform.Rotate(0f, -90f, 0f, Space.Self);
					}


					// Place block
					if (Input.GetMouseButtonDown(1) && timer < 0)
					{
						Destroy(preview);
						Quaternion rot = Quaternion.Euler(preview.transform.eulerAngles);
						GameObject finishedBlock = Instantiate(prefabPlaceList[randIdx], hit.point, rot);
						placedBlocks.Add(finishedBlock);
						//Debug.Log("Obj placed at " + hit.point);
						//Debug.Log(placedBlocks.Count);


						// Select new shape to place next
						randIdx = Random.Range(0, prefabPlaceList.Count);
						preview = Instantiate(prefabPreList[randIdx], transform.position, transform.rotation);
						timer = 2; // is equal to seconds
					}
				}
			}
		} else {
			
		}
	}

	public void setActive(){
		gameObject.SetActive(true);
	}

	public void setInactive()
	{
		gameObject.SetActive(false);
	}

	public void reset(){
		for (int i = 0; i < placedBlocks.Count; i++){
			Destroy(placedBlocks[i]);
		}
		//Debug.Log("List length is: "+placedBlocks.Count);
	}
}
