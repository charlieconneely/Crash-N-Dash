using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> roads;
    public Road road; 
    private float roadOffset = 400f;

    // Start is called before the first frame update
    void Start()
    {
        road = Component.FindObjectOfType<Road>();
        // order list of roads by their z transform position
        if (roads != null && roads.Count > 0) {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    // move road at the beginning of list to the end
    public void MoveRoad() {
        // get first road obj in list
        GameObject movedRoad = roads[0];
        // remove it from list
        roads.Remove(movedRoad);
        // find new z pos - z pos of last item in list + offset
        float newZPos = roads[roads.Count - 1].transform.position.z + roadOffset;
        // set transform of first road to this
        movedRoad.transform.position = new Vector3(750, 1, newZPos);
        // add to end of list
        roads.Add(movedRoad);
        road.SpawnObstacles();
    }
}
