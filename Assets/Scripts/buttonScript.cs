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
    public void OnMouseUpAsButton(){
        Obj.GetComponent<NewBehaviourScript>().started = true;
    }
}
