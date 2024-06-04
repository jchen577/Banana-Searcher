using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;    
public class Timertext : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI winningText;
    [SerializeField] TextMeshProUGUI losingText;
    float elapsedTime = 15;
    public GameObject Obj;
    [SerializeField] NavMeshAgent agent;
    public bool endGame = false;
	// Update is called once per frame
	void Start(){
        timerText.text = elapsedTime.ToString();
        var TempColor = winningText.color;
        TempColor.a = 0f;
        winningText.color = TempColor;
        TempColor = losingText.color;
        TempColor.a = 0f;
        losingText.color = TempColor;
    }
    void Update()
    {
        if (Obj.GetComponent<NewBehaviourScript>().started == true)
        {
            // if (agent.velocity.x==0 && agent.velocity.y == 0 &&  elapsedTime < 14){
            // if agent reached its destination https://discussions.unity.com/t/how-can-i-tell-when-a-navmeshagent-has-reached-its-destination/52403/10
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance && !endGame)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        var col = losingText.color;
                        col.a = 1f;
                        losingText.color = col;
                        endGame = true;
                    }
                }
            }
            if (!endGame)
            {
                if (elapsedTime > 0)
                {
                    elapsedTime -= Time.deltaTime;
                    timerText.text = elapsedTime.ToString();
                }
                else
                {
                    agent.isStopped = true;
                    elapsedTime = 0;
                    timerText.text = elapsedTime.ToString();
                    var col = winningText.color;
                    col.a = 1f;
                    winningText.color = col;
					endGame = true;
                    Obj.GetComponent<NewBehaviourScript>().started = false;
				}
			}
        }
    }

    public void resetTime(){
        elapsedTime = 15;
        endGame = false;
		var TempColor = winningText.color;
		TempColor.a = 0f;
		winningText.color = TempColor;
		TempColor = losingText.color;
		TempColor.a = 0f;
		losingText.color = TempColor;
	}
}
