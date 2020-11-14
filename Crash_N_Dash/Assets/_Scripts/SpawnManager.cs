using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    RoadSpawner roadSpawner;
    Rigidbody rb = new Rigidbody();
    
    void Start() {
        roadSpawner = GetComponent<RoadSpawner>();
        rb = GetComponent<Rigidbody>();
    }

    public void SpawnTriggerEntered() {
        roadSpawner.MoveRoad();
    }
}
