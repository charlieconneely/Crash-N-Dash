using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints; 
    [SerializeField] GameObject smallBarrier;
    [SerializeField] GameObject bigBarrier;

    void Start() {
        FillArrayWithChildren();
        SpawnObstacles();
    }

    public void ReceiveRoad(GameObject road) {
        foreach(Transform child in road.transform) {
            if (child.tag == "SpawnPoint") {
                
            }
        }
    }

    public void RespawnObstacles() {
        Debug.Log("Called");
        SpawnObstacles();
    }

    public void SpawnObstacles() {
        SpawnSmallBarriers();
        SpawnBigBarriers();
    }

    private void FillArrayWithChildren() {
        foreach(Transform child in transform) {
            if (child.tag == "SpawnPoint") spawnPoints.Add(child.gameObject);
        }
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
