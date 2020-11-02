using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;

    void Start() {
        setExposure(0f);    
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
    }

    public void setExposure(float value) {
        RenderSettings.skybox.SetFloat("_Exposure", value);
    }
    
}
