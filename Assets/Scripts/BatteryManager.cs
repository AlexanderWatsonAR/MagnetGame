using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryManager : MonoBehaviour
{
    public GameObject doorHinge;
    public GameObject doorHandle;

    [HideInInspector]
    private static BatteryManager instance;

    private static float batteryStatus = 100.0f;
    private static float consumptionRate = 0f;

    private float meterStep = 0.9f;
    private float meterHeight;

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
            instance.UpdateBatteryStatus(value);
        }
    }

    public static float ConsumptionRate
    {
        get
        {
            return consumptionRate;
        }
        set
        {
            consumptionRate = value;
        }
    }

    void Start()
    {
        instance = this;
        batteryStatus = 100;
        IsMagnetActive = true;
        meterHeight = transform.localScale.z;
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
                GetComponent<Renderer>().material.color = red;
            }
            else
            {
                GetComponent<Renderer>().material.color = green;
            }

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z - (meterStep *  consumptionRate));
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void UpdateBatteryStatus(float charge)
    {
        float newCharge = transform.localScale.z + ((charge / 100) * meterHeight);
        newCharge = newCharge < 90 ? 90 : 90;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newCharge);
        
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(3);
        doorHandle.GetComponent<Animator>().enabled = true;
    }
}
