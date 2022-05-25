using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class PlayerHPSystem : MonoBehaviour
{
    public int Playerhealth = 15;
    public GameObject DeadMessage1;
    public GameObject DeadMessage2;
    public GameObject DeadMessage3;
    public GameObject DeadMessage4;
    [SerializeField] GameObject DeathSound;
    public GameObject Player;
    [SerializeField] AudioSource ouch;
    private float OverhealTimer = 1;

    private void Start()
    {
        OverhealTimer = 3;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Playerhealth++;
        }
        if (Playerhealth > 15 && OverhealTimer <= 0)
        {
            Playerhealth -= 1;
            OverhealTimer = 3;
        }
        OverhealTimer -= Time.deltaTime;
    }
    public void TakeDamage(int damage)
    {
        Playerhealth += damage;
        OverhealTimer = 10;
        PlayerUITracker.instance.PlayerHPUIUpdate(Playerhealth);
        ouch.Play();
        if (Playerhealth <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        DeathSound.SetActive(true);
        if (DeadMessage1 != null)
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
