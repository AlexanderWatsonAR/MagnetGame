using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryManager : MonoBehaviour
{
    [HideInInspector]
    public static BatteryManager instance;

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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        text = GetComponent<TextMeshProUGUI>();
    }

    public IEnumerator UpdateBatteryStatus()
    {
        while (isMagnetActive)
        {
            batteryStatus -= consumptionRate;
            if (batteryStatus <= 0.0f)
                IsMagnetActive = false;
            int roundedBatteryStatus = (int)batteryStatus;
            text.text = roundedBatteryStatus.ToString() + "%";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
