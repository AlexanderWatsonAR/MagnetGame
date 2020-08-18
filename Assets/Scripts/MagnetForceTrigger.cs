using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagnetForceTrigger : MonoBehaviour
{
    public float strength;
    //public TextMeshProUGUI buttonText;

    public GameObject CatchZone;

    private void OnTriggerEnter(Collider other)
    {
        MagnetForce(other);
    }

    private void OnTriggerStay(Collider other)
    {
        MagnetForce(other);
    }

    private void OnTriggerExit(Collider other)
    {
        MagnetForce(other);
    }

    void MagnetForce(Collider other)
    {
        if (other.tag == "Metallic" && BatteryManager.IsMagnetActive)
        {
            if (!other.gameObject.GetComponent<CollectableProperties>().isMagnetic)
                return;

            if (other.gameObject.GetComponent<CollectableProperties>().isDiamagnetic)
                strength = -strength;

            Vector3 direction = Vector3.Normalize(CatchZone.transform.position - other.transform.position);
            if (other.attachedRigidbody != null)
                other.attachedRigidbody.AddForce(direction * (strength));

            if (strength < 0)
                strength *= -1;
        }

    }

    //public void MagnetActive()
    //{
    //    BatteryManager.IsMagnetActive = BatteryManager.IsMagnetActive == true ? false : true;

    //    if (BatteryManager.IsMagnetActive)
    //        buttonText.text = "on";
    //    else
    //        buttonText.text = "off";
    //}
}
