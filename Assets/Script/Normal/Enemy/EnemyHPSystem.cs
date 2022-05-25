using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;
using UnityEngine.Audio;
public class EnemyHPSystem : MonoBehaviour
{
    public int health = 50;
    public bool Exploder = true;
    public bool Shotgunimmune = false;
    //public GameObject deathEffect;
    [SerializeField] ObjectPool Explosive;
    [SerializeField] ObjectPool DeathEffectyPool;
    [SerializeField] GameObject Self;
    [SerializeField] AudioSource hit;

    public void TakeDamage(int damage, bool Shotgun)
    {
        if (Shotgun == true && Shotgunimmune == true)
        {
            health -= damage / 3;
        }
        else
        {
            health -= damage;
        }
       
        if (hit != null) 
        { 
            hit.Play(); 
        }
       
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
        if(Explosive != null)
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
        Destroy(gameObject);
    }
}
