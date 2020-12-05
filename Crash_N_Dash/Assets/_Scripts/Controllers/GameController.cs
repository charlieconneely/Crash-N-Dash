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
    [SerializeField] Text signsText;
    private int pointsValue = 50;
    private int speedSigns = 0;

    void Update() {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        signsText.text = "Signs: " + speedSigns;
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

    public void AddSpeedSign() {
        speedSigns++;
        Debug.Log("speed signs: " + speedSigns);
    }

    public bool HasSpeedSign() {
        if (speedSigns > 0) {
            speedSigns--;
            return true;
        }
        return false;
    }

    IEnumerator GameOver() {
        Destroy(GameObject.Find("Player"));
        yield return new WaitForSeconds(3f);
        Debug.Log("Back to main menu");
    }
}
