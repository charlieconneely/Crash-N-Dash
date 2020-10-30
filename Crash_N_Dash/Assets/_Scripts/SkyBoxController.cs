using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
        // RenderSettings.skybox.SetFloat("_Exposure", 7.1f);
    }
}
