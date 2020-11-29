using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float exposureIncreaseSpeed = 0.001f;
    private float exp = 0f;
    private bool increase = true;

    void Start() {
        setExposure(exp);    
    }

    // Update is called once per frame
    void Update() {
        // Slowly increase skybox exposure
        handleExposure();
        // Slowly rotate skybox 
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }

    private void handleExposure() {
        // every 2 seconds... 
        if (System.DateTime.Now.Second % 2 == 0) {
            switch (increase) {
                case true: 
                    if (exp < 10f) {
                        exp += exposureIncreaseSpeed;
                    } else {
                        increase = false;
                    }
                    break;
                case false:
                    if (exp > 0f) {
                        exp -= exposureIncreaseSpeed;
                    } else {
                        increase = true;
                    }
                    break;
            }
            setExposure(exp);
        }
    }

    private void setExposure(float value) {
        RenderSettings.skybox.SetFloat("_Exposure", value);
    }   
}
