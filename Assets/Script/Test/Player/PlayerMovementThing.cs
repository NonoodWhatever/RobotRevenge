using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementThing : MonoBehaviour
{// credit to Brackeys
    public float moveSpeed = 5f;


    public Rigidbody2D Phys;
    public Camera cam;


    Vector2 movement;
    Vector2 mousePos;
    
    public void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);



    }

    public void FixedUpdate()
    {
        Phys.MovePosition(Phys.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - Phys.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; // subtract if player's facing wrong direction.
        Phys.rotation = angle;

    }

}
