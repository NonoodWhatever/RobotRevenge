using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;
public class Enemy_Energy_Bullet : MonoBehaviour
{
    [SerializeField] ObjectPool SelfPool;
    [SerializeField] ObjectPool HitEffectPool;
    public int Damage; 
    private float DelayBeforeDestroy = 30.0f;
    private float DelayBeforeStopEffect = 0.5f;
    private void OnEnable()
    {
        DelayBeforeDestroy = 30.0f;
        DelayBeforeStopEffect = 0.5f;
    }

    // Update is called once per frame
    void Update()
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
        PlayerHPSystem player = collision.GetComponent<PlayerHPSystem>();
        if(player != null)
        {
            player.TakeDamage(-Damage);
        }
        HitEffectPool.GetObject(transform.position, Quaternion.identity);
        SelfPool.Release(gameObject);
    }
}
