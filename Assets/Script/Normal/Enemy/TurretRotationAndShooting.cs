using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;
public class TurretRotationAndShooting : MonoBehaviour
{   //Brackeys's based
    [SerializeField] Transform target;
    public float range = 10f;
   
    public string enemyTag = "Player";

    public Transform partToRotate;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public ObjectPool bulletPrefabPool;
    public Transform firePoint1;
    public Transform firePoint2;
    public float bulletForce = 10f;
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] TheTarget = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject closestPlayer = null;
    foreach (GameObject target in TheTarget)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                closestPlayer = target;
            }
        }
    if (closestPlayer != null && shortestDistance <= range)
        {
            target = closestPlayer.transform;
        }
    else
        {
            target = null;
        }
    }

    private void Update()
    {
        fireCountdown -= Time.deltaTime;
        if (target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation,Time.deltaTime*2).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,0f,rotation.z);

        if(fireCountdown <= 0f)
        {
            Shoot1();
            shoot2();
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
    }
    void shoot2()
    {
        GameObject bullet = bulletPrefabPool.GetObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint2.transform.position;
            bullet.transform.rotation = firePoint2.transform.rotation;
            Rigidbody2D PhysRB2 = bullet.GetComponent<Rigidbody2D>();
            PhysRB2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
