using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    void Update() {
        Drive();
    }

    private void Drive() {
        if (!PauseMenu.isGamePaused) {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                transform.localPosition.y,
                transform.localPosition.z - speed);        
        }
    }
}
