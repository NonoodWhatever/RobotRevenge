using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;

public class EnergyBulletP : MonoBehaviour
{
    //public GameObject HitEffect;
    [SerializeField] ObjectPool SelfPool;
    [SerializeField] ObjectPool HitEffectPool;
    [SerializeField] ObjectPool ExplosivePool;
    public int Damage;
    //public GameObject Explosion;
    private float DelayBeforeDestroy = 30.0f;
    private float DelayBeforeStopEffect = 0.5f;
    private void OnEnable()
    {
        DelayBeforeDestroy = 30.0f;
        DelayBeforeStopEffect = 0.5f;
    }
    private void Update()
    {
         DelayBeforeDestroy -= Time.deltaTime;
         if (DelayBeforeDestroy <= 0)
         {
            SelfPool.Release(gameObject);
         }
        DelayBeforeStopEffect -= Time.deltaTime;
        if (DelayBeforeStopEffect <= 0)
        {
            HitEffectPool.Release(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //GameObject effect = 
            
        EnemyHPSystem enemy = collision.GetComponent<EnemyHPSystem>();
        if (enemy != null && ExplosivePool == null)
        {

            enemy.TakeDamage(Damage);
        }
        else if (enemy != null && ExplosivePool != null)
        {
            enemy.TakeDamage(Damage);
            ExplosivePool.GetObject();
            ExplosivePool.GetObject(transform.position, Quaternion.identity);
        }
        else if (enemy == null && ExplosivePool != null)
        {
            ExplosivePool.GetObject();
            ExplosivePool.GetObject(transform.position, Quaternion.identity);
        }
        //DelayBeforeDestroy = 0.0005f;
        HitEffectPool.GetObject(transform.position, Quaternion.identity);
        SelfPool.Release(gameObject);
        // Destroy(effect, 5f);
        // Destroy(gameObject);

    }
}
