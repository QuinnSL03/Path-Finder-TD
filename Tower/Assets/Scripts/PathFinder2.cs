using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder2 : MonoBehaviour
{
    public Transform endPoint;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Awake() 
    {
        agent = GetComponent<NavMeshAgent> ();
    
    }
       

        
    
    
    // Update is called once per frame
    void Update()
    {
        if(GameController.start)
        {  
            agent.SetDestination(endPoint.transform.position);
        }
    }
    
}
