using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;

public class ExplosiveScript : MonoBehaviour
{
    [SerializeField] ObjectPool itspool;
    float Timer = 0.4f;
    [SerializeField]
    int damage = 5;
    public bool RPG = false;
    public bool Exploder = false;
    private void OnEnable()
    {
        Timer = 0.4f;
    }
    private void Update()
    {
        if (Timer <= 0)
        {
            itspool.Release(gameObject);
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHPSystem enemy = collision.GetComponent<EnemyHPSystem>();
        if (enemy != null && Timer > 0)
        {
            if (RPG == false)
          {
                enemy.TakeDamage(damage);
          }
            else
          {
                enemy.TakeDamage(10000);
          }
        }
        if(Exploder == true || RPG == true)
        {
            PlayerHPSystem player = collision.GetComponent<PlayerHPSystem>();
            if(player != null && Timer > 0)
            {
                player.TakeDamage(-5);
            }
            if(enemy!= null && Timer > 0)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
