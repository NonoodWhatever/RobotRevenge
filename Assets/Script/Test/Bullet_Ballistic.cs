using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Ballistic : MonoBehaviour
{

    public GameObject HitEffect;
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        EnemyHPSystem enemy = collision.GetComponent<EnemyHPSystem>();
        if(enemy != null)
        {
            enemy.TakeDamage(10);
        }
        Destroy(effect, 5f);
        Destroy(gameObject);




    }


}
