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
    TMP_Text HPCheck;
    [SerializeField]
    TMP_Text Objective;
    [SerializeField]
    Slider Ammo;
    [SerializeField]
    TMP_Text EToActivate;
    bool EisOnactive;
    int Health;
   public void PlayerHPUIUpdate(int healthchange)
    {
        Health = healthchange;
        HPCheck.text = "Hit Point:" + Health;
    }
    public void PlayerAmmoUIUpdate(int ammotochange, int ammoMax)
    {
        Ammo.maxValue = ammoMax;
        Ammo.value = ammotochange;
    }
    public void ObjectiveUIUpdate(Text thingTochange)
    {
        Objective.text = "Objective:" + thingTochange;
    }
    public void PressEtoPickup(bool SetActiveYN)
    {
        if(SetActiveYN = true)
        {
            EisOnactive = true;
        }
    }
}
