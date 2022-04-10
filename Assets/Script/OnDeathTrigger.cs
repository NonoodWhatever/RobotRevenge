using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathTrigger : MonoBehaviour
{
    public GameObject ItemToActive1;
    public GameObject ItemToActive2;
    public GameObject ItemToSleep1;
    public GameObject ItemToSleep2;
 public void Destroyed()
    {
        if (ItemToActive1 != null) { ItemToActive1.SetActive(true); }
        if (ItemToActive2 != null) { ItemToActive2.SetActive(true); }
        if (ItemToSleep1 != null) { ItemToSleep1.SetActive(false); }
        if (ItemToSleep2 != null) { ItemToSleep2.SetActive(false); }
    }
}
