using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBulletP : MonoBehaviour
{
    public GameObject HitEffect;
    public int Damage;
    public GameObject Explosion;
    private float DelayBeforeDestroy = 60.0f;

    private void Update()
    {
        DelayBeforeDestroy -= Time.deltaTime;
        if (DelayBeforeDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        EnemyHPSystem enemy = collision.GetComponent<EnemyHPSystem>();
        if (enemy != null && Explosion == null)
        {
            
                enemy.TakeDamage(Damage);
            DelayBeforeDestroy = 0.05f;

        }
        else if (enemy != null &&Explosion != null)
        {
            enemy.TakeDamage(Damage);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            DelayBeforeDestroy = 0.0005f;
        }
        else if (enemy == null && Explosion != null)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            DelayBeforeDestroy = 0.0005f;
        }
        
       // Destroy(effect, 5f);
       // Destroy(gameObject);

    }
}
