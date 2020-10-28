using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private float yOffset = 2f;
    private float zOffset = -10f;
    
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yOffset, player.position.z + zOffset);        
    }
}
