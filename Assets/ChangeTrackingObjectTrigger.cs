using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrackingObjectTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<TrackObject>().trackers[0].anObject.GetComponent<Animator>().enabled = true;
        other.GetComponent<TrackObject>().enabled = false;
        
        GetComponent<BoxCollider>().enabled = false;
        enabled = false;
    }
}
