using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSelection : MonoBehaviour
{
    public GameObject PlayerNonMelee;
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject PlayerWeaponMelee;
    public GameObject Grenade;
    public GameObject WeaponSP;
    private void Awake()
    {
        PlayerNonMelee.SetActive(true);
        Weapon1.SetActive(true);
        Weapon2.SetActive(true);
    //    Grenade.SetActive(true);
    }
    void Start()
    {
        PlayerNonMelee.SetActive(true);
        Weapon1.SetActive(true);
        Weapon2.SetActive(false);
     //   Grenade.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            PlayerNonMelee.SetActive(true);
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
            PlayerWeaponMelee.SetActive(false);
      //      Grenade.SetActive(false);
            WeaponSP.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            PlayerNonMelee.SetActive(true);
            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            PlayerWeaponMelee.SetActive(false);
        //    Grenade.SetActive(false);
            WeaponSP.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            PlayerNonMelee.SetActive(false);
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            PlayerWeaponMelee.SetActive(true);
          //  Grenade.SetActive(false);
            WeaponSP.SetActive(false);
        }
      //  if (Input.GetKey(KeyCode.Alpha4))
      //  {
       //     PlayerNonMelee.SetActive(true);
       //     Weapon1.SetActive(false);
       //     Weapon2.SetActive(false);
        //    PlayerWeaponMelee.SetActive(false);
           // Grenade.SetActive(true);
        //    WeaponSP.SetActive(false);
      //  }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            PlayerNonMelee.SetActive(true);
            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            PlayerWeaponMelee.SetActive(false);
         //   Grenade.SetActive(false);
            WeaponSP.SetActive(true);
        }
    }
    
}
