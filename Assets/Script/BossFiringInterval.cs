using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;
using UnityEngine.Audio;
public class BossFiringInterval : MonoBehaviour
{
    public float fireRate = 1f;
    [SerializeField] float fireCountdown = 0f;

    public ObjectPool bulletPrefabPool;
    public Transform firePoint1;
    public float bulletForce = 10f;
    [SerializeField] AudioSource FireSound;

    void Update()
    {
        fireCountdown -= Time.deltaTime;
        if (fireCountdown <= 0f)
        {
            Shoot1();
            fireCountdown = 1f / fireRate;
        }
    }
    void Shoot1()
    {
        GameObject bullet = bulletPrefabPool.GetObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint1.transform.position;
            bullet.transform.rotation = firePoint1.transform.rotation;
            Rigidbody2D PhysRB = bullet.GetComponent<Rigidbody2D>();
            PhysRB.AddForce(firePoint1.up * bulletForce, ForceMode2D.Impulse);
        }
if (FireSound != null)
        {
            FireSound.Play();
        }
    }
}
