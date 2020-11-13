using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnPoints; 
    [SerializeField] GameObject barrier;

    void Start() {
        SpawnBarriers();
    }

    public void SpawnBarriers() {
        int position1 = Random.Range(0, 5);

        Vector3 pos1 = new Vector3(spawnPoints[position1].transform.position.x,
                                   spawnPoints[position1].transform.position.y,
                                   spawnPoints[position1].transform.position.z);

        Instantiate(barrier, pos1, barrier.transform.rotation);
    }
}
