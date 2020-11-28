﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints; 
    public List<GameObject> laneBlockers;
    [SerializeField] GameObject car;
    [SerializeField] GameObject trafficCone;
    [SerializeField] GameObject petrolCan;
    private GameObject road;
    private int zOffset = 175;
    private int xOffset = 40;
    private int[] xBoundaries = {762, 845};

    /* Receive road from RoadSpawner */
    public void ReceiveRoad(GameObject r) {
        road = r;
        spawnPoints.Clear();
        laneBlockers.Clear();
        PopulateSpawnPointArray();
        SpawnObstacles();
    }

    private void PopulateSpawnPointArray() {
        foreach(Transform child in road.transform) {
            if (child.tag == "SpawnPoints") {
                foreach(Transform subchild in child.transform) {
                    if (subchild.tag == "SpawnPoint") spawnPoints.Add(subchild.gameObject);
                }
            }
        }
    }

    private bool DiceRoll(int odds) {
        var num1 = Random.Range(0, odds);
        var num2 = Random.Range(0, odds);
        if (num1 == num2) return true;
        return false;
    }

    private void SpawnObstacles() {
        SpawnCar();
        SpawnObject(trafficCone);
        SpawnObject(petrolCan);
         /* if odds met - block lane */
        if (DiceRoll(2)) BlockLane();
    }

    private void BlockLane() {
        foreach(Transform child in road.transform) {
            if (child.tag == "LaneBlockers") {
                foreach(Transform subchild in child.transform) { 
                    laneBlockers.Add(subchild.gameObject);
                }
            }
        }
        /* pick a random lane to block */
        var lane = Random.Range(0, laneBlockers.Count);
        laneBlockers[lane].SetActive(true);
    }

    private void SpawnCar() {
        var index = Random.Range(0, 6);
        Vector3 pos = new Vector3(spawnPoints[index].transform.position.x,
                                  spawnPoints[index].transform.position.y + 1.98f,
                                  spawnPoints[index].transform.position.z);
        Instantiate(car, pos, car.transform.rotation);        
    }

    private void SpawnObject(GameObject obj) {
        /* Instantiate object somewhere on current
        road (x, z) transform */
        var zPos = Random.Range(road.transform.position.z - zOffset,
                                road.transform.position.z + zOffset);
        var xPos = Random.Range(xBoundaries[0], xBoundaries[1]);
        Vector3 position = new Vector3(xPos, road.transform.position.y, zPos);
        Instantiate(obj, position, obj.transform.rotation);
    }

    // private void SpawnTrafficCones() {
    //     /* Instantiate traffic cone somewhere on current
    //     road (x, z) transform */
    //     var zPos = Random.Range(road.transform.position.z - zOffset,
    //                             road.transform.position.z + zOffset);
    //     var xPos = Random.Range(xBoundaries[0], xBoundaries[1]);
    //     Vector3 position = new Vector3(xPos, road.transform.position.y, zPos);
    //     Instantiate(trafficCone, position, trafficCone.transform.rotation);
    // } 
}
