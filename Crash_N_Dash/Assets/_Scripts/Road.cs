using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPoints; 
    [SerializeField] GameObject smallBarrier;
    [SerializeField] GameObject bigBarrier;

    void Start() {
        SpawnObstacles();
    }

    public void SpawnObstacles() {
        SpawnSmallBarriers();
        SpawnBigBarriers();
    }

    private void SpawnSmallBarriers() {
        Vector3 position = spawnPoints[Random.Range(0, 5)].transform.position;
        Instantiate(smallBarrier, position, smallBarrier.transform.rotation);       
    }

    private void SpawnBigBarriers() {
        Vector3 position = spawnPoints[Random.Range(6, 12)].transform.position;
        Instantiate(bigBarrier, position, bigBarrier.transform.rotation);       
    }
}
