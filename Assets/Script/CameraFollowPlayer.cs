using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform PlayerObject;
    public Vector3 offset;

    void Update()
    {
        transform.position = new Vector3(PlayerObject.position.x + offset.x, PlayerObject.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
        // this code OP Thanks to Shinyclef!
    }
}
