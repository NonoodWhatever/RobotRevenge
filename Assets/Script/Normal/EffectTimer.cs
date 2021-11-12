using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.MOP2;
public class EffectTimer : MonoBehaviour
{
   
    [SerializeField] ObjectPool itspool;
    float Timer = 0.5f;
     void OnEnable()
    {
        Timer = 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            itspool.Release(gameObject);
        }
    }
}
