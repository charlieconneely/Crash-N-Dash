using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] SpawnManager spawnManager;
    [SerializeField] float xClampL = 760f;
    [SerializeField] float xClampR = 848f;
    [SerializeField] float controlYawFactor = 15f;
    [SerializeField] float yawFactor = 0.5f;
    [SerializeField] float speed = 1f;
    private float maxSpeed = 7f;
    private float speedIncreaseRate = 0.5f;
    [SerializeField] GameObject explosionFX;

    GameController gc = new GameController();
    private Rigidbody rb = new Rigidbody();
    private float hMovement;

    void Start() {
        rb = GetComponent<Rigidbody>();
        gc = Component.FindObjectOfType<GameController>();
    }

    void Update() {
        Drive();
        Rotate();
    }

    private void Drive() {
        hMovement = Input.GetAxis("Horizontal");

        float xOffset = hMovement * (speed * 0.3f);
        float xPosition = Mathf.Clamp(transform.localPosition.x + xOffset, xClampL, xClampR);

        transform.localPosition = new Vector3(xPosition, transform.localPosition.y, transform.localPosition.z + speed);

        if (speed < maxSpeed) IncrementSpeed();
    }

    private void Rotate() {
        float yaw = transform.localPosition.y * yawFactor + (hMovement * controlYawFactor);
        transform.localRotation = Quaternion.Euler(0f, yaw, 0f);    
    }

    private void IncrementSpeed() {
        /* Every x seconds - increment speed */
        if (System.DateTime.Now.Second % 10 == 0) {
            speed += speedIncreaseRate * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        switch (other.tag) 
        {
            case "SpawnTrigger":
                spawnManager.SpawnTriggerEntered();
                break;
            case "BarrierTrigger":
            case "Car":
                Instantiate(explosionFX, transform.position, explosionFX.transform.rotation);
                gc.LoseLife();
                break;
            case "Cone":
                gc.LosePoints();
                break;
            case "PetrolCan":
                gc.GainPoints();
                break;
        } 
    }
}
