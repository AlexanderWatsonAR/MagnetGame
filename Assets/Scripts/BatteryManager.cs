using System.Collections;
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

    private static bool isMagnetActive = false;

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
        }
    }

    void Start()
    {
        instance = this;
        text = GetComponent<TextMeshProUGUI>();
        batteryStatus = 100;
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
            yield return new WaitForSeconds(0.5f);
        }
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
