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
    bool EisOnactive;
    int Health;
    public void PlayerHPUIUpdate(int healthchange)
    {
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
        Objective.text = "Objective:" + thingTochange;
    }
    public void PressEtoPickup(bool SetActiveYN)
    {
        if(SetActiveYN == true)
        {
            EisOnactive = true;
        }
    }
}
