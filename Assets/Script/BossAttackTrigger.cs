using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackTrigger : MonoBehaviour
{
    [SerializeField]
    Animator BossTrigger;
    [SerializeField] bool Left;
    [SerializeField] bool Front;
    [SerializeField] bool Right;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHPSystem Player = collision.GetComponent<PlayerHPSystem>();
        if (Player != null)
        {
            if (Left == true)
            {
                BossTrigger.SetTrigger("PlayerSpottedLeft");
            }
            if (Front == true)
            {
                BossTrigger.SetTrigger("PlayerSpottedFront");
            }
            if (Right == true)
            {
                BossTrigger.SetTrigger("PlayerSpottedRight");
            }
        }
    }
}
