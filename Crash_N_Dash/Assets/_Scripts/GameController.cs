using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int lives = 3;

    public void LoseLife() {
        lives--;
        Debug.Log(lives);
        if (lives < 1) {
            Destroy(GameObject.Find("Player"));
        }    
    }
}
