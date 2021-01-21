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

    public float consumptionRate = 1f;

    public GameObject BatteryImage;
    private RectTransform batteryImageRect;

    private Color green = new Color(0.08741736f, 1.0f, 0.0f);
    private Color red = new Color(1.0f, 0.1084906f, 0.1336466f);

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
        }
    }

    void Start()
    {
        instance = this;
        text = GetComponent<TextMeshProUGUI>();
        batteryStatus = 100;
        batteryImageRect = BatteryImage.GetComponent<RectTransform>();
        IsMagnetActive = true;
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
            if(batteryStatus <= 15.0f)
            {
                BatteryImage.GetComponent<UnityEngine.UI.Image>().color = red;
            }
            else
            {
                BatteryImage.GetComponent<UnityEngine.UI.Image>().color = green;
            }
            int roundedBatteryStatus = (int)batteryStatus;
            text.text = roundedBatteryStatus.ToString() + "%";
            batteryImageRect.sizeDelta = new Vector2(roundedBatteryStatus * 2, batteryImageRect.sizeDelta.y);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
