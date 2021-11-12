using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveScript : MonoBehaviour
{
    public float Timer = 0.05f;
    [SerializeField]
    int damage = 5;
    public bool RPG = false;
    
    private void Update()
    {
        if (Timer <= 0)
        {
            Destroy(gameObject);
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
                enemy.TakeDamage(1000);
          }
        }
    }
}
