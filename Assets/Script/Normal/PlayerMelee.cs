using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        {
            EnemyHPSystem enemy = collision.GetComponent<EnemyHPSystem>();
            if (enemy != null)
            {
                enemy.TakeDamage(2, false);
            }
        }
    }

}
