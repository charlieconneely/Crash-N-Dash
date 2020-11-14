﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Transform player;
    private float offset = 20f;

    void Start() {
        player = GameObject.Find("Player").transform;
    }

    void Update() {
        // if player has gone past - self destruct
        if (transform.position.z < player.position.z - offset) {
            Destroy(gameObject);
        }
    }
}   