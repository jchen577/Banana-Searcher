using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public GameObject Obj;
    void Start()
    {
        //Obj = GameObject.FindGameObjectWithTag("NewBehaviourScript");
    }
    void Update(){
        this.gameObject.transform.position = Camera.main.transform.position;
        this.gameObject.transform.Translate(-10,-3,-1);
    }
    public void SetStartTrue(){
        Obj.GetComponent<NewBehaviourScript>().started = true;
    }
	public void SetStartFalse()
	{
		Obj.GetComponent<NewBehaviourScript>().started = false;
	}
}
