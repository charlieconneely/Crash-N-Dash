using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    [SerializeField] GameObject pauseMenuUI;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        PlaySound();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    void Pause() {
        PlaySound();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    public void RestartGame() {
        PlaySound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
        PlaySound();
        isGamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PlaySound() {
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
