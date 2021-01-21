using UnityEngine;
using UnityEngine.EventSystems;

public class DragRotate : MonoBehaviour
{
    public GameObject Hinge;
    public Vector3 minRotation;
    public Vector3 maxRotation;
    float rotSpeed = 300;

    void Start()
    {

    }

	void OnMouseDown()
    {
        Debug.Log("Lever");
    }

	void OnMouseDrag()
    {
        //float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        Hinge.transform.Rotate(Vector3.right, rotY);
        Hinge.transform.localRotation = new Quaternion(Hinge.transform.localRotation.x,0,0, Hinge.transform.localRotation.w);

        if (Hinge.transform.localEulerAngles.x >= maxRotation.x)
        {
            Vector3 maxAngle = new Vector3(maxRotation.x, transform.parent.rotation.eulerAngles.y, transform.parent.rotation.eulerAngles.z);
            Hinge.transform.localEulerAngles = maxAngle;
        }

        if (Hinge.transform.localEulerAngles.x <= minRotation.x)
        {
            Vector3 minAngle = new Vector3(maxRotation.x, transform.parent.rotation.eulerAngles.y, transform.parent.rotation.eulerAngles.z);
            Hinge.transform.localEulerAngles = minAngle;
        }

    }	
}