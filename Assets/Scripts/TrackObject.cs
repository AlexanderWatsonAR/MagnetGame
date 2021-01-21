using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tracker
{
    public GameObject anObject;
    public Vector3 offset;
}

public class TrackObject : MonoBehaviour
{
    public Tracker[] trackers;

    // Update is called once per frame
    void Update()
    {
        Track();
    }

    public void Track()
    {
        Vector3 position = transform.localPosition;
        
        foreach (Tracker tracker in trackers)
        {
            tracker.anObject.transform.localPosition = new Vector3(position.x + tracker.offset.x, position.y + tracker.offset.y, position.z + tracker.offset.z);
        }
    }
         
}
