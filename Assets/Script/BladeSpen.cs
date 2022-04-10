using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeSpen : MonoBehaviour
{
    public GameObject Itself;
    // Update is called once per frame
    void Update()
    {
        Itself.transform.Rotate(0, 0, 20);
    }
}
