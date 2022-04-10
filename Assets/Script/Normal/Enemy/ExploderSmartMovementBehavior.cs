using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ExploderSmartMovementBehavior : MonoBehaviour
{
    [SerializeField] GameObject Target;
    NavMeshAgent agent;
  
 
    private void Start()
    {
        Target = null;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    
    }
    void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Target = GameObject.Find("NewPlayerThing");
        if (Target != null)
        {
            agent.SetDestination(Target.transform.position);
        }
    }

 
}


