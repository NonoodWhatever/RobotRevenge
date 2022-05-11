using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiTimeBugCheck : MonoBehaviour
{
    [SerializeField] float TimeCheck;
    private void Start()
    {
        TimeCheck = Time.timeScale;
    }
    public void Checkmate()
    {
        if (TimeCheck != 1)
        {
            Time.timeScale = 1f;
        }
    }
}
