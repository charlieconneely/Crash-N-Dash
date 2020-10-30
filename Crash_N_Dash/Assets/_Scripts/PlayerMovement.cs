using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] SpawnManager spawnManager;
    [SerializeField] float xClampL = 760f;
    [SerializeField] float xClampR = 845f;
    private Rigidbody rb = new Rigidbody();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Drive();
    }

    private void Drive() 
    {
        float hMovement = Input.GetAxis("Horizontal");
        float vMovement = Input.GetAxis("Vertical");

        float xOffset = hMovement * (speed/2);
        float zOffset = vMovement * speed;

        float xPosition = Mathf.Clamp(transform.localPosition.x + xOffset, xClampL, xClampR);

        transform.localPosition = new Vector3(xPosition, transform.localPosition.y, transform.localPosition.z + (zOffset));
    }

    private void OnTriggerEnter(Collider other) {
        switch (other.tag) 
        {
            case "SpawnTrigger":
                spawnManager.SpawnTriggerEntered();
                Debug.Log("Hit spawn trigger");
                break;
        } 
    }
}
