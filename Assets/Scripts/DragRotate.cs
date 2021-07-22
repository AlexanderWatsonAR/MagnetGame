using UnityEngine;
using UnityEngine.EventSystems;

public class DragRotate : MonoBehaviour
{
    public GameObject Hinge;
    Vector3 hingeEulerAngle;
    public Vector3 minRotation;
    public Vector3 maxRotation;
    float rotSpeed = 300;
    float magnetStrenthStep;

    public GameObject Painting;

    //Number Wheels
    public GameObject hundreds;
    public GameObject tens;
    public GameObject ones;

    void Start()
    {
        magnetStrenthStep = 1.2f;
        hingeEulerAngle = minRotation;
    }

	void OnMouseDown()
    {
    }

	void OnMouseDrag()
    {
        //float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        Hinge.transform.Rotate(Vector3.right, rotY);
        Hinge.transform.localRotation = new Quaternion(Hinge.transform.localRotation.x,0,0, Hinge.transform.localRotation.w);
        hingeEulerAngle.x += rotY;

        if (hingeEulerAngle.x > maxRotation.x)
        {
            Vector3 maxAngle = new Vector3(maxRotation.x, transform.parent.rotation.eulerAngles.y, transform.parent.rotation.eulerAngles.z);
            Hinge.transform.localEulerAngles = maxAngle;
            hingeEulerAngle.x = maxRotation.x;
        }

        if (hingeEulerAngle.x < minRotation.x)
        {
            Vector3 minAngle = new Vector3(maxRotation.x, transform.parent.rotation.eulerAngles.y, transform.parent.rotation.eulerAngles.z);
            Hinge.transform.localEulerAngles = minAngle;
            hingeEulerAngle.x = minRotation.x;
        }

        float percentile = hingeEulerAngle.x - 220;

        float newMagnetStrength = percentile * magnetStrenthStep;
        float batteryConsumption = percentile / 100;
        float opacity = percentile / 100;

        Color newColour = Painting.GetComponent<Renderer>().material.color;
        newColour.a = opacity;

        Painting.GetComponent<Renderer>().material.color = newColour;

        if (percentile < 10)
        {
            ones.GetComponent<RotateToFixedPoints>().TargetRotation = (int)percentile;
            tens.GetComponent<RotateToFixedPoints>().TargetRotation = 0;
            hundreds.GetComponent<RotateToFixedPoints>().TargetRotation = 0;
        }
        if (percentile >= 10 && percentile < 100)
        {
            int firstUnit = (Mathf.Abs((int)percentile / 10));
            int secondUnit = (int)percentile - (firstUnit * 10);

            ones.GetComponent<RotateToFixedPoints>().TargetRotation = secondUnit;
            tens.GetComponent<RotateToFixedPoints>().TargetRotation = firstUnit;
            hundreds.GetComponent<RotateToFixedPoints>().TargetRotation = 0;
        }
        if (percentile == 100)
        {
            ones.GetComponent<RotateToFixedPoints>().TargetRotation = 0;
            tens.GetComponent<RotateToFixedPoints>().TargetRotation = 0;
            hundreds.GetComponent<RotateToFixedPoints>().TargetRotation = 1;
        }

        MagnetForceTrigger.Strength = newMagnetStrength;
        BatteryManager.ConsumptionRate = batteryConsumption;
        //Debug.Log(percentile);
    }	
}