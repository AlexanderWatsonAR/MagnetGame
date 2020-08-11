using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagnetForceTrigger : MonoBehaviour
{
    public float strength;
    public TextMeshProUGUI buttonText;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Metallic" && BatteryManager.IsMagnetActive)
        {
            Vector3 direction = Vector3.Normalize(transform.position - other.transform.position);
            if(other.attachedRigidbody != null)
                other.attachedRigidbody.AddForce(direction * (strength));
        }
    }

    public void MagnetActive()
    {
        BatteryManager.IsMagnetActive = BatteryManager.IsMagnetActive == true ? false : true;

        if (BatteryManager.IsMagnetActive)
            buttonText.text = "on";
        else
            buttonText.text = "off";
    }
}
