using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{ public GameObject Player;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           ShootRayCast();
        }
    }

    void ShootRayCast()
    {
        RaycastHit ouchie;

        if (Physics.Raycast(Player.transform.position, Input.mousePosition, out ouchie))
        {
            Debug.Log(ouchie.transform.name);
        }
    }
}
