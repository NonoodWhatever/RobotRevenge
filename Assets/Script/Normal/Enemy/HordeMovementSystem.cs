using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HordeMovementSystem : MonoBehaviour
{
    [SerializeField] Rigidbody2D Itself;
    NavMeshAgent agent;
    [SerializeField] GameObject Enemy;
    // Start is called before the first  void Start()
   
    void Start()
    {
        Itself = this.GetComponent<Rigidbody2D>();
        Enemy = GameObject.Find("NewPlayerThing");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Update()
{
    Enemy = GameObject.Find("NewPlayerThing");
    Enemy = GameObject.FindGameObjectWithTag("Player");
    if (Enemy != null)
    {
            agent.SetDestination(Enemy.transform.position);
            Vector3 direction = Enemy.transform.position - transform.position;
     //   Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y * 2, direction.x * 2) * Mathf.Rad2Deg;
        Itself.rotation = angle;
    }
}

}
