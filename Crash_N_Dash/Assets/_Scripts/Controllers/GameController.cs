using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text livesText;
    private int pointsValue = 50;

    void Update() {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }

    public void LoseLife() {
        lives--;
        Debug.Log(lives);
        if (lives < 1) StartCoroutine("GameOver");
    }

    public void GainPoints() {
        score += pointsValue;
        Debug.Log("Score: " + score);
    }

    public void LosePoints() {
        if (score <= 0) return; 
        score -= pointsValue;
        Debug.Log("Score: " + score);
    }

    IEnumerator GameOver() {
        Destroy(GameObject.Find("Player"));
        yield return new WaitForSeconds(3f);
        Debug.Log("Back to main menu");
    }
}
