using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUITracker : MonoBehaviour
{
    public static PlayerUITracker instance;
    private void Awake()
    {
        instance = this;
    }
    [SerializeField]
    TMP_Text HPCheckText;
    [SerializeField]
    Slider HPCheckSlider;
    [SerializeField]
    TMP_Text Objective;
    [SerializeField]
    Slider AmmoSlide;
    [SerializeField]
    TMP_Text AmmoText;
    [SerializeField]
    TMP_Text EToActivate;
    [SerializeField]
    TMP_Text RELOAD;
    [SerializeField]
    RawImage OUCHIE;
    bool EisOnactive;
    int Health;
    float timer;
    float ouchtimer;
    private void Start()
    {
        timer = 5;
        ouchtimer = 0;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        ouchtimer -= Time.deltaTime;
        if(timer <= 0)
        {
            Objective.gameObject.SetActive(false);
        }
        else
        {
            Objective.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Tab) )
        {
            timer = 2;
        }
        if(ouchtimer <= 0)
        {
            OUCHIE.gameObject.SetActive(false);
        }
    }
    public void PlayerHPUIUpdate(int healthchange)
    {
        if( healthchange < Health)
        {
            OUCHIE.gameObject.SetActive(true);
            ouchtimer = 0.2f;
        }
        Health = healthchange;
        if (HPCheckText != null) 
        { 
            HPCheckText.text = "Hit Point:" + Health;
        }
        if (HPCheckSlider != null)
        {
            HPCheckSlider.maxValue = 15;
            HPCheckSlider.value = Health;
        }
    }
    public void PlayerAmmoUIUpdate(int ammotochange, int ammoMax)
    {
        if (AmmoSlide != null)
        {
            AmmoSlide.maxValue = ammoMax;
            AmmoSlide.value = ammotochange;
        }
        if (AmmoText != null)
        {
            AmmoText.text = ammotochange + " / " + ammoMax;
        }
    }
    public void ObjectiveUIUpdate(Text thingTochange)
    {
        timer = 4;
        Objective.text = "Objective:" + thingTochange;
    }
    public void PressEtoPickup(bool SetActiveYN)
    {
        if(SetActiveYN == true)
        {
            EisOnactive = true;
        }
    }

    public void ReloadDone(bool Reloading)
    {
        if (Reloading == true)
        {
            RELOAD.gameObject.SetActive(true);
        }
        else
        {
            RELOAD.gameObject.SetActive(false);
        }
    }

}
