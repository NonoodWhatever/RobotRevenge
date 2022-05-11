using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderBoomTrigger : MonoBehaviour
{
    [SerializeField] EnemyHPSystem uhoh;
    [SerializeField] GameObject Beep;

    float Timer = 4.0f;

    void Start()
    {
        Timer = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer <= 0)
        {
            uhoh.TakeDamage(10000, false);
        }
        if (Beep.activeSelf == true)
        {
            Timer -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collided)
    {
        PlayerHPSystem Player = collided.GetComponent<PlayerHPSystem>();
        if (Player != null)
        {
            if (Beep != null)
            {
                Beep.SetActive(true);
                uhoh.health = 20;
            }
        }

    }
}
