using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderLookingBehavior : MonoBehaviour
{
    [SerializeField] Rigidbody2D Itself;
    [SerializeField] GameObject Enemy;
    void Start()
    {
        Itself = this.GetComponent<Rigidbody2D>();
        Enemy = GameObject.Find("NewPlayerThing");
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.Find("NewPlayerThing");
        Enemy = GameObject.FindGameObjectWithTag("Player");
        if (Enemy != null)
        {
            Vector3 direction = Enemy.transform.position - transform.position;
           // Debug.Log(direction);
            float angle = Mathf.Atan2(direction.y * 2, direction.x * 2) * Mathf.Rad2Deg;
            Itself.rotation = angle - 90;
        }
    }
}
