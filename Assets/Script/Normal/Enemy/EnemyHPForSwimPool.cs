using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;
public class EnemyHPForSwimPool : MonoBehaviour
{
    public int Maxhealth = 50;
    [SerializeField] int health = 50;
    public bool Exploder = true;
    //public GameObject deathEffect;
    [SerializeField] ObjectPool Explosive;
    [SerializeField] ObjectPool DeathEffectyPool;
    [SerializeField] ObjectPool ItsSpawnPool;
    [SerializeField] GameObject Self;

    private void OnEnable()
    {
        health = Maxhealth;
    }

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
        if (DeathEffectyPool != null)
        {
            DeathEffectyPool.GetObject(transform.position, Quaternion.identity);
        }
        if (Explosive != null)
        {
            Explosive.GetObject(transform.position, Quaternion.identity);
        }
        if (Self != null)
        {
            OnDeathTrigger Trig = Self.GetComponent<OnDeathTrigger>();
            if (Trig != null)
            {
                Trig.Destroyed();
            }
        }
        ItsSpawnPool.Release(gameObject);
    }
}
