using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;

public class EnemyHPSystem : MonoBehaviour
{
    public int health = 50;
    public bool Exploder = true;
    //public GameObject deathEffect;
    [SerializeField] ObjectPool Explosive;
    [SerializeField] ObjectPool DeathEffectyPool;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Ded();
        }
    }

    void Ded()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        DeathEffectyPool.GetObject(transform.position, Quaternion.identity);
        if(Explosive != null)
        {
            Explosive.GetObject();
        }
        Destroy(gameObject);
    }
}
