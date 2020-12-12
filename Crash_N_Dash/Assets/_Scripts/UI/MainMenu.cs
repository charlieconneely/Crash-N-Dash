using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        PlaySound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() 
    {
        PlaySound();
        Debug.Log("Quitting game.");
        Application.Quit();
    }

    public void PlaySound() {
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
