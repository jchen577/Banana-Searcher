using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public bool started = false;
    public NavMeshAgent agent;
    private GameObject goal;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.Find("banana");
    }

    // Update is called once per frame
    void Update()
    {
        if(started == true){
			agent.isStopped = false;
			agent.SetDestination(goal.transform.position);
        } else {
            agent.isStopped = true;
        }
    }
}
