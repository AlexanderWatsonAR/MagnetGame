using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintMagnetMarker : MonoBehaviour
{
    public GameObject Painting;
    Vector3 rayPosition;

    private float xPos;
    private float yPos;
    // Start is called before the first frame update
    void Start()
    {
        xPos = 2.76f;
        yPos = 1.5f;

        rayPosition = new Vector3(transform.position.x + xPos, transform.position.y - yPos, transform.position.z);
        RaycastHit hitInfo;
        Physics.Raycast(rayPosition, Vector3.down, out hitInfo, 25);

        if (hitInfo.collider.name == "RampBoxCollider")
        {
            Vector3 paintPoint = hitInfo.point;
            Vector3 aVec = new Vector3(paintPoint.x - xPos, paintPoint.y, paintPoint.z);
            Painting.transform.position = aVec;
        }

        Debug.DrawRay(rayPosition, Vector3.down * 25, Color.red);
    }

    public void Paint()
    {
    }
}
