using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    public float rotateSpeed;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.localEulerAngles.x < transform.localEulerAngles.x)
            other.transform.localEulerAngles = new Vector3(other.transform.localEulerAngles.x + (rotateSpeed * Time.smoothDeltaTime), other.transform.localEulerAngles.y, other.transform.localEulerAngles.z);
        else
            GetComponent<RotateTrigger>().enabled = false;
        if (Vector3.Distance(transform.position, other.transform.position) < 0.2f)
            GetComponent<TrackObject>().enabled = false;
    }
}
