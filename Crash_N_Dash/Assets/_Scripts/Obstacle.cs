using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Transform player;
    private float offset = 150f;

    void Start() {
        player = GameObject.Find("Player").transform;
    }

    void Update() {
        /* if player is dead or passed by */
        if (player == null || transform.position.z < player.position.z - offset) {
            Destroy(gameObject);
        } 
    }
}   
