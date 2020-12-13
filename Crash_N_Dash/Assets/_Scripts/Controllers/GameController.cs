using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text livesText;
    [SerializeField] Text signsText;
    [SerializeField] Text speedText;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] TextMeshProUGUI menuScore;
    [SerializeField] TextMeshProUGUI finalScore;
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject Ranked;
    private HighScoreManager highScoreManager;
    private int pointsValue = 50;
    private int speedSigns = 0;
    private float displaySpeed = 10f;
    private bool ranked = false;

    void Start() {
        highScoreManager = FindObjectOfType<HighScoreManager>();
        StartCoroutine("StartGame");
    }

    void Update() {
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
        signsText.text = speedSigns.ToString();
        speedText.text = displaySpeed.ToString("F1") + " km/h";
        menuScore.text = finalScore.text = "YOUR SCORE: " + score;
    }

    public void GainLife() {lives++;}

    public void LoseLife() {
        if (lives > 0) lives--;
        if (lives < 1) StartCoroutine("GameOver");
    }

    public void GainPoints() {
        score += pointsValue;
    }

    public void LosePoints() {
        if (score <= 0) return; 
        score -= pointsValue;
    }

    public void AddSpeedSign() {
        speedSigns++;
    }

    public bool HasSpeedSign() {
        if (speedSigns > 0) {
            speedSigns--;
            return true;
        }
        return false;
    }

    public void setDisplaySpeed(float speed) {
        displaySpeed = speed * 10f;
    }

    IEnumerator GameOver() {
        Destroy(GameObject.Find("Player"));
        ranked = highScoreManager.CheckScore(score);
        yield return new WaitForSeconds(1f);
        GameOverMenu.SetActive(true);
        if (ranked) {
            Ranked.SetActive(true);
        } else {
            Ranked.SetActive(false);
        }
    }

    IEnumerator StartGame() {
        yield return new WaitForSeconds(1f);
        countdown.text = "2";
        yield return new WaitForSeconds(1f);
        countdown.text = "1";
        yield return new WaitForSeconds(1f);
        countdown.gameObject.SetActive(false);
    }
}
