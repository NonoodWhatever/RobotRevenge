using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotationAndShooting : MonoBehaviour
{
    private Transform target;
    public float range = 10f;

    public string enemyTag = "Player";

    public Transform partToRotate;
    public float fireCountdown = 0f;

   

    // Update is called once per frame
    void UpdatetoTarget()
    {
    
    }
}
