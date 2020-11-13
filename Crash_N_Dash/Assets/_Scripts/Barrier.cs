using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private Transform player;

    void Start() {
        player = GameObject.Find("Player").transform;
    }

    void Update() {
        // if player has gone past - self destruct
        if (transform.position.z < player.position.z) {
            Destroy(gameObject);
        }
    }
}
