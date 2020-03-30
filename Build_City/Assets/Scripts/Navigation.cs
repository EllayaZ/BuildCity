using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public Vector3 target;
    private NavMeshAgent navMeshAgent;


    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.destination = target;
        
        //navMeshAgent.destination = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void SetNewTarget(Vector3 target)
    {
        this.target = target;
    
    
    }
}
