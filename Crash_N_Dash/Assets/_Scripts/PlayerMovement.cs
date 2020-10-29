using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] SpawnManager spawnManager;
    private Rigidbody rb = new Rigidbody();
    private bool onRoad = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onRoad) {
            Drive();
        } else {
            StartFalling();
        }
    }

    private void Drive() 
    {
        float hMovement = Input.GetAxis("Horizontal");
        float vMovement = Input.GetAxis("Vertical");
        Vector3 playerVelocity = new Vector3(hMovement * speed, rb.velocity.y, vMovement * (speed/2));
        rb.velocity = playerVelocity;
        transform.Translate(playerVelocity);
    }

    private void StartFalling()
    {
        Vector3 playerVelocity = new Vector3(0, -10, 0);
        transform.Translate(playerVelocity);
    }

    private void OnTriggerEnter(Collider other) {
        switch (other.tag) 
        {
            case "SpawnTrigger":
                spawnManager.SpawnTriggerEntered();
                Debug.Log("Hit spawn trigger");
                break;
            case "BarrierTrigger":
                FallOffRoad();
                Debug.Log("Hit barrier");
                break;
        }
    }

    private void FallOffRoad()
    {
        onRoad = false;
    }
}
