using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableScript : MonoBehaviour
{
    public void enableObject(){
		gameObject.SetActive(true);
	}

	public void disableObject()
	{
		gameObject.SetActive(false);
	}
}
