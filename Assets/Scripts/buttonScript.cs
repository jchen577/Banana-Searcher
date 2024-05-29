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
    private void OnMouseUpAsButton(){
        Obj.GetComponent<NewBehaviourScript>().started = true;
    }
}
