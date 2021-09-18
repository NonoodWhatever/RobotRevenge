using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //Credit to SPG from stuartspixelgames.com for this.
    //The note is pretty good. Guide said inital code is bad, so improvement is needed.
    //The note also said I need to know programming a bit, luckily I have touched code before.
    Rigidbody2D dude;

    float Xthing;
    float Ything;
    float Udiagon = 0.6f;

    public float Walkspeed = 16.0f;

    void Start()
    {
        dude = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Looking();
        // -1 and 1. Controll SPEED
        Xthing = Input.GetAxisRaw("Horizontal");
        Ything = Input.GetAxisRaw("Vertical");
        //I think the getaxisraw("thing") have to be this way, else it doesn't work
    }
  //  private void Dudemove()
    //{
        //if (Input.GetKeyDown())
   // }
    private void FixedUpdate()
    {
        if (Xthing != 0 && Ything != 0)
        {
            Xthing *= Udiagon;
            Ything *= Udiagon;

        }
        dude.velocity = new Vector2(Xthing * Walkspeed, Ything * Walkspeed);
    }
    private void Looking()
    { // This code credit to robertbu in answer unity
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
