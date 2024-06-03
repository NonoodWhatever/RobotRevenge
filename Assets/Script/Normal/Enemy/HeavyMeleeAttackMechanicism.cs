using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyMeleeAttackMechanicism : MonoBehaviour
{
    [SerializeField] GameObject AttackingArea;
    [SerializeField] int NonPlayerDamage;
    [SerializeField] bool IsPlayerInArea = false;
    [SerializeField] float Timer;
    [SerializeField] GameObject Player;
    [SerializeField] PlayerHPSystem PlayerHP;
    void Start()
    {
        Timer = 2;
    }

    // Update is called once per frame
    void Update()
    {if (Player == null)
        {
            Player = GameObject.Find("NewPlayerThing");
            PlayerHP = null;
        }
        else
        {
            PlayerHP = Player.GetComponent<PlayerHPSystem> ();
        }
       
        Timer -= Time.deltaTime;
            if(Timer <= 0)
       {
            if (IsPlayerInArea == true)
            {
                if (PlayerHP != null)
             { 
                PlayerHP.TakeDamage(-1);
                   
             }

            }
            Timer = 1;
        }
    }
    [SerializeField]
    EnemyHPSystem EverythingElse;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayerHP != null)
        {
            IsPlayerInArea = true;
        }
        //EverythingElse = collision.GetComponent<EnemyHPSystem>();



    }
    private void OnTrigger2D(Collider2D collision)
    {
       
        if (EverythingElse != null)
        {
            EverythingElse.TakeDamage(NonPlayerDamage, false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (PlayerHP != null) 
        { 
            IsPlayerInArea = false; 
        }
      //  EverythingElse = null;
    }

}
