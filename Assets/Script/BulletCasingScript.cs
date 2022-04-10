using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;

public class BulletCasingScript : MonoBehaviour
{
    [SerializeField] ObjectPool CasingPool;
    public float timer;
    private float timething;

    // test

    private void OnEnable()
    {
        timething = timer;
    }
    void Update()
    {
        timething -= Time.deltaTime;
        if (timething <= 0)
        {
         CasingPool.Release(gameObject);
        }
    }
}
