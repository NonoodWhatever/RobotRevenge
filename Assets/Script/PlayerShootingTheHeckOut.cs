using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingTheHeckOut : MonoBehaviour
{
    //Planned to be combination of Shooting with Raycast scrtip by Unity Tech and thfm's
    public Gun gun;

    public int shootButton;
    public KeyCode reloadKey;

    void Update()
    {
        if (Input.GetMouseButton(shootButton))
        {
            gun.Shoot();
        }

        if (Input.GetKeyDown(reloadKey))
        {
            gun.Reload();
        }
    }
}
