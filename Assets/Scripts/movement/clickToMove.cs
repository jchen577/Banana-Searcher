using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript2 : MonoBehaviour
{
    public GameObject Obj;
    private GameObject banana;
    // Start is called before the first frame update
    void Start()
    {
        banana = GameObject.Find("banana");
    }

    // Update is called once per frame
    void Update()
    {
        if(Obj.GetComponent<NewBehaviourScript>().started == false){
        //if(gameObject.activeSelf == false){
            if(Input.GetMouseButtonDown(0)){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Input.mousePosition.y < transform.position.y+ 1200){
                    RaycastHit hit;
                    if(Physics.Raycast(ray,out hit)){
                        banana.transform.position = hit.point;
                    }
                }
            }
        }
    }
}
