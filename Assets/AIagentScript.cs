using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIagentScript : MonoBehaviour
{
    NavMeshAgent AI_agent;
    

    // Start is called before the first frame update
    void Start()
    {
        AI_agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit)) {
                if(hit.collider != null){
                    AI_agent.SetDestination(hit.point);
                }
            }
       } 
    }
}
