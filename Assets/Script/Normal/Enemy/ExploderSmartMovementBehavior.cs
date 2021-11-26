using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExploderSmartMovementBehavior : MonoBehaviour
{
    public GameObject Target;
    NavMeshAgent agent;
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        Target = GameObject.Find("NewPlayerThing");
        agent.SetDestination(Target.transform.position);
    }
}
