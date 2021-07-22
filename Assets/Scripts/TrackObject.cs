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
    public float speed;
    public Tracker[] trackers;

    // Update is called once per frame
    void Update()
    {
        if (speed > 0)
            Track(speed);
        else
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
    public void Track(float speed)
    {
        Vector3 position = transform.position;

        foreach (Tracker tracker in trackers)
        {
            Vector3 Direction = Vector3.Normalize(position - (tracker.anObject.transform.position + tracker.offset));

            tracker.anObject.transform.position += Direction * speed * Time.smoothDeltaTime;
        }
    }
         
}
