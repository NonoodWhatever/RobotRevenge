using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPSystem : MonoBehaviour
{
    public int Playerhealth = 15;
    public GameObject DeadMessage1;
    public GameObject DeadMessage2;
    public GameObject DeadMessage3;
    public GameObject DeadMessage4;
    public GameObject Player;
    
    
    public void TakeDamage(int damage)
    {
        Playerhealth += damage;

        if (Playerhealth <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        DeadMessage1.SetActive(true);
        DeadMessage2.SetActive(true);
        DeadMessage3.SetActive(true);
        DeadMessage4.SetActive(true);
        print("ded");
        Player.SetActive(false);

    }

    
}
