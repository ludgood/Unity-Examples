using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class DefaultAvatarScript : MonoBehaviour
{

    public Transform[] waypoints = new Transform[4];
    private int currentWaypoint; 
    private bool startRoute;

    NavMeshAgent AI_agent;
    Animator AI_animator;


    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
        AI_agent = GetComponent<NavMeshAgent>();
        AI_animator = GetComponent<Animator>();
        startRoute = false;
        AI_agent.autoBraking = true;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E) && startRoute == false) 
       {
           startRoute = true;
           AI_agent.SetDestination(waypoints[currentWaypoint].position);
           AI_animator.Play("Base Layer.Run");
       }

       if(startRoute == true && AI_agent.remainingDistance < 0.1) 
       {
           currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
           AI_agent.SetDestination(waypoints[currentWaypoint].position);
       }

           
       }
    }

