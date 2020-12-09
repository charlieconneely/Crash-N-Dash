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
    [SerializeField] GameObject explosionFX;

    private float maxSpeed = 7f;
    private float speedIncreaseRate = 0.5f;
    private bool hasSpeedSigns = false;
    private bool countdownOver = false;

    GameController gc = new GameController();
    private Rigidbody rb = new Rigidbody();
    private float hMovement;

    void Start() {
        rb = GetComponent<Rigidbody>();
        gc = Component.FindObjectOfType<GameController>();
        StartCoroutine("WaitForCountdown");
    }

    void Update() {
        if (!countdownOver) return; 
        Drive();
        Rotate();
        if (speed < maxSpeed) IncrementSpeed();
    }

    private void Drive() {
        hMovement = Input.GetAxis("Horizontal");
        float xOffset = hMovement * (speed * 0.4f);
        float xPosition = Mathf.Clamp(transform.localPosition.x + xOffset, xClampL, xClampR);
        transform.localPosition = new Vector3(xPosition, transform.localPosition.y, transform.localPosition.z + speed);
        
        /* Use speed sign to slow down */ 
        if (Input.GetKeyDown("space")) {
            hasSpeedSigns = gc.HasSpeedSign();
            if (hasSpeedSigns) StartCoroutine("SlowDown");
        }
    }

    private void Rotate() {
        float yaw = transform.localPosition.y * yawFactor + (hMovement * controlYawFactor);
        transform.localRotation = Quaternion.Euler(0f, yaw, 0f);    
    }

    private void IncrementSpeed() {
        /* Every x seconds - increment speed */
        if (System.DateTime.Now.Second % 10 == 0) {
            speed += speedIncreaseRate * Time.deltaTime;
            /* set display speed on canvas */
            gc.setDisplaySpeed(speed);
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
                Destroy(other.gameObject);
                break;
            case "SpeedSign":
                gc.AddSpeedSign();
                Destroy(other.gameObject);
                break;
            case "Engine":
                gc.GainLife();
                Destroy(other.gameObject);
                break;
        } 
    }

    IEnumerator SlowDown() {
        speed = speed * 0.5f;
        yield return new WaitForSeconds(5f);
        speed = speed * 2;
    }

    IEnumerator WaitForCountdown() {
        yield return new WaitForSeconds(3f);
        countdownOver = true;
    }
}
