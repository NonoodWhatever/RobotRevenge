using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingThing : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefabSelection;

    public float bulletForce = 20f;
 
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
         


        }
    }

    void Shoot()
    {
       GameObject bullet = Instantiate(BulletPrefabSelection, firePoint.position, firePoint.rotation);
       Rigidbody2D PhysRB = bullet.GetComponent<Rigidbody2D>();
        PhysRB.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
