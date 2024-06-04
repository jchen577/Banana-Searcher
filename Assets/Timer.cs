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
        if(Obj.GetComponent<NewBehaviourScript>().started == true){
            if(agent.velocity.x==0 && agent.velocity.y == 0 &&  elapsedTime < 14){
                var col = losingText.color;
                col.a = 1f;
                losingText.color = col;
            }
            else if(elapsedTime >0){
                elapsedTime -= Time.deltaTime;
                timerText.text = elapsedTime.ToString();
            }
            else{
                elapsedTime =0;
                timerText.text = elapsedTime.ToString();
                var col = winningText.color;
                col.a = 1f;
                winningText.color = col;
            }
        }
    }
}
