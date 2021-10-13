using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackingTrigger : MonoBehaviour
{
    [SerializeField]
    Animator EnemyTrigger;
 

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHPSystem Player = collision.GetComponent<PlayerHPSystem>();
        if (Player != null)
        {
            EnemyTrigger.SetTrigger("PlayerSpotted");
        }
    }
  
}
