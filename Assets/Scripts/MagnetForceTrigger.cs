using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagnetForceTrigger : MonoBehaviour
{
    public GameObject BatterySmash;
    private static float strength;

    public static float Strength
    {
        get
        {
            return strength;
        }
        set
        {
            strength = value;
        }
    }

    public GameObject CatchZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CollectableProperties>() != null)
        {
            if (!other.gameObject.GetComponent<CollectableProperties>().isMagnetic)
                return;

            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            MagnetForce(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        float dis = CatchZone.transform.position.y - other.transform.position.y;
        if (other.name == "Core" && dis < 1.0f)
        {
            BatteryManager.BatteryStatus += other.gameObject.GetComponent<CollectableProperties>().charge;
            Instantiate(BatterySmash);
            BatterySmash.transform.position = other.gameObject.transform.position;
            BatterySmash.transform.rotation = other.gameObject.transform.rotation;
            //BatterySmash.transform.localScale = other.gameObject.transform.localScale;
            Destroy(other.gameObject);
        }

        MagnetForce(other);
    }

    private void OnTriggerExit(Collider other)
    {
        MagnetForce(other);
    }

    void MagnetForce(Collider other)
    {
        if (strength <= 0)
            return;

        if (other.tag == "Metallic")
        {
            if (!other.gameObject.GetComponent<CollectableProperties>().isMagnetic)
                return;

            Vector3 force = CatchZone.transform.position - other.transform.position;

            if (force.y < 5f && force.y > 2f)
            {
                force.x *= strength * 2;
                force.y *= strength;
                force.z *= strength * 2;
                force *= Time.smoothDeltaTime;
            }
            if (force.y < 2f && force.y > 1f)
            {
                force = force * (strength * 5) * Time.smoothDeltaTime;
            }
            if (force.y < 1f)
            {
                force = force * (strength * 20) * Time.smoothDeltaTime;
            }
            else
            {
                force = force * strength * Time.smoothDeltaTime;
            }

            if (other.attachedRigidbody != null)
                other.attachedRigidbody.AddForce(force);

        }
    }
}
