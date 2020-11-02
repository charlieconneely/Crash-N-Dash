using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] SpawnManager spawnManager;
    [SerializeField] SkyBoxController skyBoxController;
    
    [SerializeField] float xClampL = 760f;
    [SerializeField] float xClampR = 848f;
    [SerializeField] float controlYawFactor = 15f;
    [SerializeField] float yawFactor = 0.5f;

    private Rigidbody rb = new Rigidbody();
    private float speed = 0.1f;
    private float hMovement;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        Drive();
        Rotate();
    }

    private void Drive() {
        hMovement = Input.GetAxis("Horizontal");

        float xOffset = hMovement * (speed * 0.3f);
        float xPosition = Mathf.Clamp(transform.localPosition.x + xOffset, xClampL, xClampR);

        transform.localPosition = new Vector3(xPosition, transform.localPosition.y, transform.localPosition.z + speed);

        if (speed < 10f) IncrementSpeed();
    }

    private void Rotate() {
        float yaw = transform.localPosition.y * yawFactor + (hMovement * controlYawFactor);
        transform.localRotation = Quaternion.Euler(0f, yaw, 0f);    
    }

    private void IncrementSpeed() {
        // every 2 seconds - increment speed 
        if (System.DateTime.Now.Second % 5 == 0) {
            speed += 0.01f;
            // increment skybox exposure respectively
            skyBoxController.setExposure(speed);
            Debug.Log(System.DateTime.Now.Second);
        }
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
