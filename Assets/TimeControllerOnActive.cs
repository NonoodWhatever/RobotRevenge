using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControllerOnActive : MonoBehaviour
{
    [SerializeField] float TimeThingy;
    void OnEnable()
    {
        Time.timeScale = TimeThingy;
    }
}
