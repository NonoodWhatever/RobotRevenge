using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMovementBehavior : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    private Rigidbody2D RBPhys;
    private Vector2 movement;
    public bool JustAttacked = false;
    public float Timer = 0f;
   
    private void Start()
    {
        RBPhys = this.GetComponent<Rigidbody2D>();
        
    }
    public void Update()
    {
        player = GameObject.Find("NewPlayerThing");
        if (player != null)
        {
            if (JustAttacked == false)
            {
                Vector3 direction = player.transform.position - transform.position;
                //  Debug.Log(direction);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                RBPhys.rotation = angle;
                direction.Normalize();
                movement = direction;
            }
            else if (JustAttacked == true)
            {
                Vector3 direction = player.transform.position - transform.position;
                //  Debug.Log(direction);
                float angle = Mathf.Atan2(direction.y * 2, direction.x * 2) * Mathf.Rad2Deg;
                RBPhys.rotation = angle;
                direction.Normalize();
                movement = -direction;
                Timer -= Time.deltaTime;
            }
        }
            if (Timer < 0)
            {
                Timer = 0;
                JustAttacked = false;
            }
        
    }

    private void FixedUpdate()
    {
        move(movement);
    }
    void move(Vector2 direction)        
    {
        RBPhys.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
