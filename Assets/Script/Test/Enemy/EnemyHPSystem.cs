using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPSystem : MonoBehaviour
{
    public int health = 50;
    public GameObject deathEffect;

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
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
