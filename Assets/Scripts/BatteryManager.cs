﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryManager : MonoBehaviour
{
    [HideInInspector]
    private static BatteryManager instance;

    private static TextMeshProUGUI text;

    private static float batteryStatus = 100.0f;

    public float consumptionRate = 10f;

    public GameObject BatteryImage;
    private RectTransform batteryImageRect;

    private static bool isMagnetActive = true;

    public static bool IsMagnetActive
    {
        get { return isMagnetActive; }
        set
        {
            isMagnetActive = value;
            if (isMagnetActive)
                instance.StartCoroutine(instance.UpdateBatteryStatus());

        }
    }

    public static float BatteryStatus
    {
        get { return batteryStatus; }
        set
        {
            batteryStatus = value;
            batteryStatus = batteryStatus >= 100.0f ? 100.0f : batteryStatus;
            int roundedBatteryStatus = (int)batteryStatus;
            text.text = roundedBatteryStatus.ToString() + "%";
            //batteryImageRect.rect.Set(batteryImageRect.rect.x, batteryImageRect.rect.y, batteryImageRect.rect.height, roundedBatteryStatus * 2);
        }
    }

    void Start()
    {
        instance = this;
        text = GetComponent<TextMeshProUGUI>();
        batteryStatus = 100;
        batteryImageRect = BatteryImage.GetComponent<RectTransform>();
    }

    public IEnumerator UpdateBatteryStatus()
    {
        while (isMagnetActive)
        {
            batteryStatus -= consumptionRate;
           
            if (batteryStatus <= 0.0f)
            {
                IsMagnetActive = false;
                StartCoroutine(EndScene());
            }
            int roundedBatteryStatus = (int)batteryStatus;
            text.text = roundedBatteryStatus.ToString() + "%";
            batteryImageRect.sizeDelta = new Vector2(roundedBatteryStatus * 2, batteryImageRect.sizeDelta.y);
            //batteryImageRect.
            yield return new WaitForSeconds(0.5f);
        }
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
