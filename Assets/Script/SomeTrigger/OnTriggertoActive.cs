using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OnTriggertoActive : MonoBehaviour
{
   public GameObject ItemToActive1;
   public GameObject ItemToActive2;
   public GameObject ItemToSleep1;
   public GameObject ItemToSleep2;
    public GameObject ItemToActiveASAP1;
    public GameObject ItemToActiveASAP2;
    public GameObject ItemToSleepASAP1;
    public GameObject ItemToSleepASAP2;
    [SerializeField] GameObject PressEToTake;
    bool Activation = false;
    [SerializeField] float Timer = 0;
    [SerializeField] bool EbuttonNeeded;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHPSystem Player = collision.GetComponent<PlayerHPSystem>();
        if (Player != null && EbuttonNeeded == false)
        {
            Activation = true;
            //if(ItemToActive1 != null) {ItemToActive1.SetActive(true); }
            // if (ItemToActive2 != null) { ItemToActive2.SetActive(true); }
            // if (ItemToSleep1 != null) { ItemToSleep1.SetActive(false); }
            // if (ItemToSleep2 != null) { ItemToSleep2.SetActive(false); }

            //   Destroy(gameObject);
        }
        if (Player != null && EbuttonNeeded == true)
        {
            PlayerUITracker.instance.PressEtoPickup(true);
        }
        else if(Player == null)
        {
            PlayerUITracker.instance.PressEtoPickup(false);
        }
        if (Player != null && EbuttonNeeded == true && Input.GetKeyDown(KeyCode.E))
        {
            Activation = true;
            PlayerUITracker.instance.PressEtoPickup(false);
            //   if (ItemToActive1 != null) { ItemToActive1.SetActive(true); }
            //   if (ItemToActive2 != null) { ItemToActive2.SetActive(true); }
            //   if (ItemToSleep1 != null) { ItemToSleep1.SetActive(false); }
            //   if (ItemToSleep2 != null) { ItemToSleep2.SetActive(false); }

            //   Destroy(gameObject);
        }

    }
    SpriteRenderer theRender;
    private void Update()
    { 
        if (Activation == true)
        {

            theRender = gameObject.GetComponent<SpriteRenderer>();
            if (theRender != null)
            {
                theRender.enabled = false;
            }
            if (ItemToActiveASAP1 != null) { ItemToActiveASAP1.SetActive(true); }
            if (ItemToActiveASAP2 != null) { ItemToActiveASAP2.SetActive(true); }
            if (ItemToSleepASAP1 != null) { ItemToSleepASAP1.SetActive(false); }
            if (ItemToSleepASAP2 != null) { ItemToSleepASAP2.SetActive(false); }
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0 && Activation == true)
        {
            if (ItemToActive1 != null) { ItemToActive1.SetActive(true); }
            if (ItemToActive2 != null) { ItemToActive2.SetActive(true); }
            if (ItemToSleep1 != null) { ItemToSleep1.SetActive(false); }
            if (ItemToSleep2 != null) { ItemToSleep2.SetActive(false); }
        }
       if (Timer <= -1 && Activation == true) { Destroy(gameObject); }

    }
}
