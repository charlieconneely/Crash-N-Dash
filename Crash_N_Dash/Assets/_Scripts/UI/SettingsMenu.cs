using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider effectsSlider;

    void Start() {
        musicSlider.value = FindObjectOfType<AudioManager>().GetVolume("Theme");
        effectsSlider.value = FindObjectOfType<AudioManager>().GetVolume("");
    }

    public void SetMusicVolume (float volume) {
        FindObjectOfType<AudioManager>().AdjustVolume(volume, "Theme");
    }

    public void SetEffectsVolume(float volume) {
        FindObjectOfType<AudioManager>().AdjustVolume(volume, "");
    }
}
