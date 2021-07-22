using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToFixedPoints : MonoBehaviour
{
    public float zSpeed;
    public int TargetRotation;

    float[] zRotations = { 342, 306, 270, 234, 198, 162, 126, 90, 54, 18 };

    void Update()
    {
        if(transform.localEulerAngles.z == zRotations[TargetRotation] ||
           (transform.localEulerAngles.z <= zRotations[TargetRotation] + 1 &&
           transform.localEulerAngles.z >= zRotations[TargetRotation] - 1))
        {
            Vector3 temp = transform.localEulerAngles;
            temp.z = zRotations[TargetRotation];
            transform.localEulerAngles = temp;
            return;
        }

        transform.Rotate(0, 0, zSpeed * Time.smoothDeltaTime);

    }
}
