using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;
public class Bullet_Ballistic : MonoBehaviour
{

    //public GameObject HitEffect;
    public int Damage;
    [SerializeField] ObjectPool itspool;
    [SerializeField] ObjectPool effectPool;
    private float DelayBeforeDestroy = 45.0f;
    private float DelayBeforeStopEffect = 0.5f;
    
    private void Update()
    {
        DelayBeforeDestroy -= Time.deltaTime;
        DelayBeforeStopEffect-= Time.deltaTime;
       if (DelayBeforeDestroy <= 0)
      {
            //Destroy(gameObject);
            itspool.Release(gameObject);
       }
        if (DelayBeforeStopEffect <= 0)
        {
            effectPool.Release(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = effectPool.GetObject(transform.position, transform.rotation);
        EnemyHPSystem enemy = collision.GetComponent<EnemyHPSystem>();
        if(enemy != null && enemy.tag != "EnemyShield")
        {
            enemy.TakeDamage(Damage);
        }
        DelayBeforeStopEffect = 0.5f;
        itspool.Release(gameObject);
        //DelayBeforeDestroy = 1.0f;
        
        // gameObject.SetActive(false);
    }
    // public void OnCollisionEnter2D(Collision2D collision)
    // {

    //    GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
    //EnemyHPSystem enemy = collision.GetComponent<EnemyHPSystem>();
    //  if (enemy != null)
    //  {
    //    enemy.TakeDamage(10);
    //   }
    //  Destroy(effect, 5f);
    //Destroy(gameObject);
    //}

}
