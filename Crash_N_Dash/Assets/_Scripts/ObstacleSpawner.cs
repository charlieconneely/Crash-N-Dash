using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints; 
    [SerializeField] GameObject smallBarrier;
    [SerializeField] GameObject bigBarrier;

    // Receive road from RoadSpawner
    public void ReceiveRoad(GameObject road) {
        spawnPoints.Clear();
        foreach(Transform child in road.transform) {
            if (child.tag == "SpawnPoints") {
                foreach(Transform subchild in child.transform) {
                    if (subchild.tag == "SpawnPoint") {
                        spawnPoints.Add(subchild.gameObject);
                    }
                }
            }
        }
        SpawnObstacles();
    }

    public void SpawnObstacles() {
        SpawnSmallBarriers();
        SpawnBigBarriers();
    }

    private void SpawnSmallBarriers() {
        Vector3 position = spawnPoints[Random.Range(0, 6)].transform.position;
        Instantiate(smallBarrier, position, smallBarrier.transform.rotation);       
    }

    private void SpawnBigBarriers() {
        Vector3 position = spawnPoints[Random.Range(6, 13)].transform.position;
        Instantiate(bigBarrier, position, bigBarrier.transform.rotation);       
    }
}
