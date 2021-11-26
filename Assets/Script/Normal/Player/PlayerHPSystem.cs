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
        PlayerUITracker.instance.PlayerHPUIUpdate(Playerhealth);
        if (Playerhealth <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {if (DeadMessage1 != null)
        {
            DeadMessage1.SetActive(true);
        }
   if (DeadMessage2 != null)
        {
            DeadMessage2.SetActive(true);
        }
     if   (DeadMessage3 != null)
        {
            DeadMessage3.SetActive(true);
        }
       if (DeadMessage4 != null)
        {
            DeadMessage4.SetActive(true);
        }
        print("ded");
        Player.SetActive(false);

    }

    
}
