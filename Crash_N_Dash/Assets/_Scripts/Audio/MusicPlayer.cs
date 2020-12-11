using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start() {
        Invoke("LoadMainMenu", 3);
    }

    private void LoadMainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
