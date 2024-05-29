using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript2 : MonoBehaviour
{
    private GameObject banana;
    // Start is called before the first frame update
    void Start()
    {
        banana = GameObject.Find("banana");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Input.mousePosition.y < 1200){
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit)){
                    banana.transform.position = hit.point;
                }
            }
        }
    }
}
