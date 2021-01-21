using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSkybox : MonoBehaviour
{
    float maxExposure = 1.09f;
    float minExposure = 0.93f;
    float step = 0.0005f;
    float exposure = 1.0f;

    float rotateX = -0.001f;

    float minRed = 0.5f;
    float maxRed = 0.62f;
    float redStep = 0.00005f;
    float fogStep = 0.0001f;
    Color skyBoxColor = new Color(0.5f, 0.5f, 0.5f);

    void Start()
    {
        //float rotation = Random.Range(0.0f, 360.0f);
        rotateX = (-0.55f)*Time.deltaTime;
        //RenderSettings.skybox.SetFloat("_Rotation", rotation);
    }

    // Update is called once per frame
    void Update()
    {
        float currentRotation = RenderSettings.skybox.GetFloat("_Rotation");
        if (PauseGame.isGamePaused)
            return;
        FluctuateExposure();
        AdjustFog(currentRotation);
        RotateBox(currentRotation);
        if (GameStopWatch.TimeElapsedInSeconds > 3.0f)
            ModulateTint();
    }

    void FluctuateExposure()
    {
        if(RenderSettings.skybox.GetFloat("_Exposure") < minExposure ||
            RenderSettings.skybox.GetFloat("_Exposure") > maxExposure)
        {
            step = -step;
        }

        exposure += step;

        RenderSettings.skybox.SetFloat("_Exposure", exposure);
    }

    void ModulateTint()
    {

        if (RenderSettings.skybox.GetColor("_Tint").r < minRed ||
            RenderSettings.skybox.GetColor("_Tint").r > maxRed)
        {
            redStep = -redStep;
        }

        skyBoxColor.r += redStep;

        RenderSettings.skybox.SetColor("_Tint", skyBoxColor);
    }

    void RotateBox(float rotation)
    {
        //float nextRotation = rotation > 360.0f ? 0.0f : rotation;
        float nextRotation = rotation < 0.0f ? 360.0f : rotation;
        float newRotation = nextRotation + rotateX;
        RenderSettings.skybox.SetFloat("_Rotation", newRotation);
    }

    void AdjustFog(float currentRotation)
    {
        if (currentRotation > 75.0f && currentRotation < 140.0f)
        {
            if (RenderSettings.fogDensity < 0.06f)
            {
                RenderSettings.fogDensity += fogStep;
            }
        }
        else
        {
            if (RenderSettings.fogDensity > 0.0f)
            {
                RenderSettings.fogDensity -= fogStep;
            }
        }
    }

    private void OnApplicationQuit()
    {
        RenderSettings.skybox.SetFloat("_Exposure", 1.0f);
        RenderSettings.skybox.SetFloat("_Rotation", 0.0f);
        RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
    }
}
