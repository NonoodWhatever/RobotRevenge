using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacking : MonoBehaviour
{
    [SerializeField] MeleeMovementBehavior MoveCheck;
    [SerializeField] GameObject AttackingArea;
    public int ouchpoint = 1;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHPSystem Player = collision.GetComponent<PlayerHPSystem>();
        if (Player != null)
        {
            Player.TakeDamage(-ouchpoint);
            if (MoveCheck != null) 
            { 
                MoveCheck.Attacked(3); 
            }
            print("ouch");
          //  if (MoveCheck.JustAttacked == false) 
          //  {
          //      MoveCheck.JustAttacked = true;
         //       MoveCheck.Timer = 2f;
          //  }
        }
        else
        {

        }

    }
}
