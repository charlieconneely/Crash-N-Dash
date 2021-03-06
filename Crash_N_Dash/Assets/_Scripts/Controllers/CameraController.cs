﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private float yOffset = 15f;
    private float zOffset = -30f;
    
    void Start() {
        player = GameObject.Find("Player").transform;
    }

    void LateUpdate() {
        if (player != null) {
            transform.position = new Vector3(player.position.x, 
                player.position.y + yOffset, 
                player.position.z + zOffset);        
        }
    }
}
