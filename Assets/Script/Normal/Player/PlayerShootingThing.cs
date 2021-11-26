using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Animations;
using QFSW.MOP2;


public class PlayerShootingThing : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] ObjectPool bulletPool;
    //public GameObject BulletPrefabSelection;
    public AudioSource Sound;

    public bool Auto;
    public bool Shotgun;
    public bool EnergyGun;

    [SerializeField] float SecondPerBullet = 10.0f;
    float SecondBeforeBullet = 0.0f ;
    
    [SerializeField] float ReloadTimeMinimum = 2.0f;
    [SerializeField] float RechargeTime= 1.0f;
    float RechargeTimer = 1.0f;
   // [SerializeField] float ReloadTimer = 0.0f;

    [SerializeField] int MaxAmmo = 30;
    [SerializeField] int CurrentAmmo;

    bool Isreloading;
    //NewObjectPoolerTest objectPooler;
    private void OnEnable()
    {
        PlayerUITracker.instance.PlayerAmmoUIUpdate(CurrentAmmo,MaxAmmo);
    }
    private void Start()
    {
        Debug.LogError("https://www.youtube.com/watch?v=pfUCdsLgr4Y");
        CurrentAmmo = MaxAmmo;
        RechargeTimer = RechargeTime;
        // objectPooler = NewObjectPoolerTest.Instance;
    }
    public float bulletForce = 20f;

    public void Update()
    {// I put reload on front instead of isreloading is in case of character not reloading properly
        PlayerUITracker.instance.PlayerAmmoUIUpdate(CurrentAmmo, MaxAmmo);
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (EnergyGun == false)
            {
                if (Shotgun != true)
                {
                    StartCoroutine(Reload());
                    return;
                }
                else
                {
                    StartCoroutine(ReloadForShotgun());
                    return;
                }
            }
            else { StartCoroutine(EarlyOverheat()); return; }
        }
        if (Isreloading) { return; }
        
        if(CurrentAmmo <= 0)
        {
            if (EnergyGun == false)
            {
                if (Shotgun != true)
                {
                    StartCoroutine(ReloadWPenalty());
                    return;
                }
                else
                {
                    StartCoroutine(ReloadForShotgun());
                    return;
                }
            }
            else
            {
                StartCoroutine(Overheat());
                return;
            }
        }
        
       
            if (Input.GetButtonDown("Fire1") && Auto == false)
            {
                if (Shotgun == false)
                {
                    Shoot();
                    CurrentAmmo--;
                }
                if (Shotgun == true)
                {
                    Shoot();
                    Shoot();
                    Shoot();
                    CurrentAmmo--;
                }
            }
            if (Input.GetButton("Fire1") && Auto == true && SecondBeforeBullet < 0)
            {
                Shoot();
                CurrentAmmo--;
                SecondBeforeBullet = SecondPerBullet;
            } 
        if(EnergyGun == true && CurrentAmmo < MaxAmmo)
        {
            RechargeTimer -= Time.deltaTime;
            if(RechargeTimer <= 0)
            {
                CurrentAmmo++;
                RechargeTimer = RechargeTime;
            }
        }
        SecondBeforeBullet-= Time.deltaTime;
    }
    #region e
    //
  //  void Shoot()
    //  {
//    GameObject bullet = Instantiate(BulletPrefabSelection, firePoint.position, firePoint.rotation);
       //   GameObject bullet = ObjectPooling.SharedInstance.GetPooledObject();
     //     if (bullet != null)
    //     {
    //        bullet.transform.position = firePoint.transform.position;
    //       bullet.transform.rotation = firePoint.transform.rotation;
    //         bullet.SetActive(true);
     //     Rigidbody2D PhysRB = bullet.GetComponent<Rigidbody2D>();
    //        PhysRB.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    //       Sound.Play();
   //  }
   // if (bullet == null)
   //  {
  //   Sound.Play();
  //   }
     //  }


    void Shoot()
    { //objectpool gives me insanity
      //GameObject bullet = Instantiate(BulletPrefabSelection, firePoint.position, firePoint.rotation);
        GameObject bullet = bulletPool.GetObject();
        //GameObject bullet = null;
        //   GameObject bullet = ObjectPooling.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.transform.position;
            bullet.transform.rotation = firePoint.transform.rotation;
            Rigidbody2D PhysRB = bullet.GetComponent<Rigidbody2D>();
            PhysRB.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            Sound.Play();
        }
        if (bullet == null)
        {
            Sound.Play();
        }
    }
    #endregion

    IEnumerator Reload()
    {
        Isreloading = true;
        yield return new WaitForSeconds(ReloadTimeMinimum);

        CurrentAmmo = MaxAmmo;
        Isreloading = false;
    }
    IEnumerator ReloadWPenalty()
    {
        Isreloading = true;
        yield return new WaitForSeconds(ReloadTimeMinimum + 2);

        CurrentAmmo = MaxAmmo - 1;
        Isreloading = false;
    }
    IEnumerator ReloadForShotgun()
    {
        Isreloading = true;
        yield return new WaitForSeconds(ReloadTimeMinimum * (MaxAmmo-CurrentAmmo));

        CurrentAmmo = MaxAmmo;
        Isreloading = false;
    }
    IEnumerator Overheat()
    {
        Isreloading = true;
        yield return new WaitForSeconds(5);

        CurrentAmmo = MaxAmmo;
        Isreloading = false;
    }
    IEnumerator EarlyOverheat()
    {
        Isreloading = true;
        yield return new WaitForSeconds(3);

        CurrentAmmo = MaxAmmo;
        Isreloading = false;
    }

    //void Shoot()
    // {
    //     if (bullet != null)
    //      {
    //    bullet.transform.position = firePoint.transform.position;
    //      bullet.transform.rotation = firePoint.transform.rotation;
    //  bullet.SetActive(true);
    //   Rigidbody2D PhysRB = bullet.GetComponent<Rigidbody2D>();
    //  PhysRB.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    //Sound.Play();
    // }
    // }
}
