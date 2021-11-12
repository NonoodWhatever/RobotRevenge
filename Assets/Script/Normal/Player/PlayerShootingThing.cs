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
    [SerializeField] float SecondPerBullet = 10.0f;
    float SecondBeforeBullet = 0.0f ;
    public bool Shotgun;
 
    //NewObjectPoolerTest objectPooler;
    
    private void Start()
    {
      
        // objectPooler = NewObjectPoolerTest.Instance;
    }
    public float bulletForce = 20f;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && Auto == false)
        {
            if (Shotgun == false)
            {
                Shoot();
            }
            if (Shotgun == true)
            {
                Shoot();
                Shoot();
                Shoot();
            }
        }
        if (Input.GetButton("Fire1") && Auto == true && SecondBeforeBullet < 0) 
        { 
                Shoot();
        SecondBeforeBullet = SecondPerBullet;
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
