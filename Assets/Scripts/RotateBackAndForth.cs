using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBackAndForth : Rotate
{
    public string axis;
    public float MaxRotation;

    // Flips rotation speed.
    protected override void ModifyRotation()
    {
        switch (axis)
        {
            case "x":
                if (transform.rotation.eulerAngles.x > MaxRotation &&
                    transform.rotation.eulerAngles.x < 360.0f - MaxRotation)
                {
                    xSpeed = -xSpeed;
                }
            break;
            case "y":
                if (transform.rotation.eulerAngles.y > MaxRotation &&
                    transform.rotation.eulerAngles.y < 360.0f - MaxRotation)
                {
                    ySpeed = -ySpeed;
                }
                break;
            case "z":
                if (transform.rotation.eulerAngles.z > MaxRotation &&
                    transform.rotation.eulerAngles.z < 360.0f - MaxRotation)
                {
                    zSpeed = -zSpeed;
                }
                break;
        }
    }
    
}
