using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectionSystem : MonoBehaviour
{
    public static WeaponSelectionSystem instanceWS;
    [SerializeField]
    public GameObject[] WeaponsSlot1;
    [SerializeField]
    public int WeaponSlot1Index;

    [SerializeField]
    public GameObject[] WeaponsSlot2;
    [SerializeField]
    public int WeaponSlot2Index;

  //  [SerializeField]
   // public GameObject[] GrenadesSlot;
   // [SerializeField]
    //public int GrenadesSlotIndex;


    [SerializeField] public GameObject[] SPWeaponsSlot;
    [SerializeField]
    public int SPWeaponsSlotIndex;

    public Dropdown WeaponSelection1DD;
    public Dropdown WeaponSelection2DD;
  //  public Dropdown GrenadeSelectionDD;
    public GameObject WholeWeaponSelection;
    
    private void Awake()
    {
        instanceWS = this;
          WeaponSlot1Index = WeaponSelection1DD.value;
          WeaponSlot2Index = WeaponSelection2DD.value;
    //    GrenadesSlotIndex = GrenadeSelectionDD.value;
        if(WeaponSlot2Index == WeaponSlot1Index)
        {
            WeaponSlot2Index++;
            if(WeaponSlot2Index <= 9)
            {
                WeaponSlot2Index = 0;
            }
            if (WeaponSlot2Index == WeaponSlot1Index)
            {
                WeaponSlot2Index++;
            }
        }

        if (WeaponsSlot1 != null && WeaponsSlot2 != null)
        //&& GrenadesSlot != null
        {
            for (int i = 0; i < 8; i++)
            {
                if (i != WeaponSlot1Index)
                {
                    WeaponsSlot1[i].SetActive(false);
                }
                else
                {
                    WeaponsSlot1[i].SetActive(true);
                }

                if (i != WeaponSlot2Index)
                {
                    WeaponsSlot2[i].SetActive(false);
                }
                else
                {
                    WeaponsSlot2[i].SetActive(true);
                }
            }
      ///
      //      for (int i2 = 0; i2 < 5; i2++)
      //      {
      //
      //          if (i2 != GrenadesSlotIndex)
      //          {
      //              GrenadesSlot[i2].SetActive(false);
      //          }
      //          else if (i2 == GrenadesSlotIndex)
      //          {
      //              GrenadesSlot[i2].SetActive(true);
      //          }
      //      }
      ///
        }
    }

    private void Start()
    {
        //[WeaponSlot1Index].SetActive(true);
        //WeaponsSlot2[WeaponSlot2Index].SetActive(true);
        // GrenadesSlot[GrenadesSlotIndex].SetActive(true);
        WholeWeaponSelection.SetActive(false);
    }
    private void Update()
    {

    }

    // Update is called once per frame
    public void Weapon1Select(int weaponchoice)
    {

    }
    public void Weapon2Select(int weaponchoice)
    {

    }
    public void GrenadeSelect(int weaponchoice)
    {

    }
}
